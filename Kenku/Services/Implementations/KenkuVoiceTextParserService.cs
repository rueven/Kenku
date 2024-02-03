using Kenku.Extensions;
using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace Kenku.Services.Implementations
{
    internal partial class KenkuVoiceTextParserService : IKenkuVoiceTextParserService
    {
        private IReadOnlyKenkuVoiceRecordingData Data { get; set; }
        private static Dictionary<int, IReadOnlyVoiceRecording> EmptyVoiceRecordingDictionary { get; } = [];
        [GeneratedRegex("RegexThatWillNeverMatchAnyThing", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
        private static partial Regex EmptyVoiceRecordingRegex();

        public void SetKenkuEmulationData(IReadOnlyList<IReadOnlyVoiceRecording> voiceRecordings)
        {
            if (!voiceRecordings.Any())
            {
                this.Data = new KenkuVoiceRecordingData()
                {
                    Pattern = EmptyVoiceRecordingRegex(),
                    VoiceRecordings = EmptyVoiceRecordingDictionary
                };
            }
            var orderedVoiceRecordings = voiceRecordings
                .OrderByDescending(x => x.Text.Length)
                .ToList();
            var builder = new StringBuilder();
            var dictionary = new Dictionary<int, IReadOnlyVoiceRecording>();
            for (var index = 0; index < orderedVoiceRecordings.Count; index++)
            {
                var voiceRecording = orderedVoiceRecordings[index];
                dictionary.Add(index, voiceRecording);
                builder
                    .Append("(?<P")
                    .Append(index)
                    .Append(">")
                    .Append(voiceRecording.Text)
                    .Append(")")
                    .Append(index == orderedVoiceRecordings.Count - 1 ? string.Empty : "|");
            }
            this.Data = new KenkuVoiceRecordingData()
            {
                Pattern = new Regex
                (
                    builder.ToString(),
                    RegexOptions.IgnoreCase | RegexOptions.Compiled
                ),
                VoiceRecordings = dictionary
            };
        }

        public IReadOnlyList<IReadOnlyKenkuVoicePart> Parse(string value)
        {
            static bool IsNestedInsideAnotherMatch((int Id, int Index, int Length, string Value) value, IEnumerable<(int Id, int Index, int Length, string Value)> allValues)
            {
                var output = allValues
                    .Any(x => !int.Equals(value.Id, x.Id) && (value.Index >= x.Index && value.Index <= (x.Index + x.Length)));
                return output;
            }
            var output = new List<IReadOnlyKenkuVoicePart>();
            var matches = this
                .Data
                .Pattern
                .Matches(value);
            var cursor = 0;
            var convertedValues = matches
                .Select(match =>
                (
                    Id: GetIdOfMatch(match.Groups) ?? -1,
                    match.Index,
                    match.Length,
                    match.Value
                ))
                .Where(x => x.Id > -1)
                .ToList();
            convertedValues = convertedValues
                .Where(x => !IsNestedInsideAnotherMatch(x, convertedValues))
                .OrderBy(x => x.Index)
                .ToList();
            for (var i = 0; i < convertedValues.Count; i++)
            {
                var convertedValue = convertedValues[i];
                if (cursor != convertedValue.Index)
                {
                    //Make sure the next catch phrase didn't have free form text infront of it
                    var text = value.Substring(cursor, convertedValue.Index - cursor);
                    foreach (var subText in text.Split('|', StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (string.IsNullOrWhiteSpace(subText))
                        {
                            continue;
                        }
                        output.Add(new KenkuVoicePart()
                        {
                            Text = subText?.Trim() ?? string.Empty,
                        });
                    }
                }
                cursor = convertedValue.Index;
                var voiceRecording = this
                    .Data
                    .FindVoiceRecord(convertedValue.Id);
                if (voiceRecording == null)
                {
                    //It matched, unable to find VoiceRecording
                    var text = value.Substring(cursor, convertedValue.Length);
                    foreach (var subText in text.Split('|', StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (string.IsNullOrWhiteSpace(subText))
                        {
                            continue;
                        }
                        output.Add(new KenkuVoicePart()
                        {
                            Text = subText?.Trim() ?? string.Empty
                        });
                    }
                }
                else
                {
                    //It matched
                    output.Add(new KenkuVoicePart()
                    {
                        Text = value.Substring(cursor, convertedValue.Length),
                        VoiceRecording = voiceRecording
                    });
                }
                cursor += convertedValue.Length;
            }
            if (cursor < value.Length)
            {
                //Make sure we capture any trailing free form text
                var text = value.Substring(cursor, value.Length - cursor);
                foreach (var subText in text.Split('|', StringSplitOptions.RemoveEmptyEntries))
                {
                    if (string.IsNullOrWhiteSpace(subText))
                    {
                        continue;
                    }
                    output.Add(new KenkuVoicePart()
                    {
                        Text = subText?.Trim() ?? string.Empty
                    });
                }
            }
            return output;
        }

        private static int? GetIdOfMatch(GroupCollection groups)
        {
            for (var i = 0; i < groups.Count; i++)
            {
                var group = groups[i];
                if (!string.IsNullOrWhiteSpace(group.Value) && group.Name.StartsWith("P"))
                {
                    var stringValue = group
                        .Name
                        .Substring(1);
                    if (int.TryParse(stringValue, out var intValue))
                    {
                        return intValue;
                    }
                }
            }
            return null;
        }
    }
}