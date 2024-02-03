using Kenku.Extensions;
using Kenku.Models.Interfaces;

namespace Kenku.WinformApplication.Extensions
{
    internal static class TreeViewExtensions
    {
        public static TreeView BindVoiceRecordings(this TreeView view, IReadOnlyList<IReadOnlyPersonality> personalities, IReadOnlyList<IReadOnlyVoiceRecording> voiceRecordings)
        {
            view.SuspendLayout();
            view.Nodes.Clear();
            view.Nodes
                .Add("All")
                .Nodes
                .AddRange
                (
                    voiceRecordings
                        .OrderBy(x => x.Text)
                        .Select(x => new TreeNode(x.Text)
                        {
                            Tag = x
                        }).ToArray()
                );
            foreach (var personality in personalities)
            {
                var personalityNode = view
                    .Nodes
                    .Add(personality.Name)
                    .With(x => x.Tag = personality);
                var relevantVoiceRecordings = voiceRecordings
                    .Where(x => x.PersonalityId == personality.Id)
                    .OrderBy(x => x.Text)
                    .ToList();
                foreach (var voiceRecording in relevantVoiceRecordings)
                {
                    personalityNode
                        .Nodes
                        .Add(new TreeNode(voiceRecording.Text)
                        {
                            Tag = voiceRecording
                        });
                }
            }
            view.ResumeLayout();
            return view;
        }
    }
}