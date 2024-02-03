using Kenku;
using Kenku.Extensions;
using Kenku.MicrosoftTextToSpeech;
using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;

namespace Tests
{
    [TestClass]
    public class DefaultTests
    {
        [TestMethod]
        public async Task CanSpeak()
        {
            var container = ServiceFactory
                .CreateContainer()
                .WithAssetDirectoryPath(new DirectoryInfo(@"Assets"))
                .WithDefaultSerializerService()
                .WithDefaultPersonalityService()
                .WithDefaultAudioResourceService()
                .WithDefaultVoiceRecordingService()
                .WithAllNAudioServices()
                .Build();
            container
                .KenkuVoiceTextParserService
                .SetKenkuEmulationData(new List<IReadOnlyVoiceRecording>());
            container
                .AddMicrosoftTextToSpeechServices();
            var outputDevice = container
                .OutputAudioDeviceServices
                .First(x => x.Name.Contains("Kraken", StringComparison.OrdinalIgnoreCase));
            await container
                .KenkuEmulationService
                .SpeakAsync("This is a|Test|of the emergency broadcast|system", outputDevice);
        }

        [TestMethod]
        public void CanParse()
        {
            var container = ServiceFactory
                .CreateContainer()
                .WithAssetDirectoryPath(new DirectoryInfo(@"Assets"))
                .WithDefaultSerializerService()
                .WithDefaultPersonalityService()
                .WithDefaultAudioResourceService()
                .WithDefaultVoiceRecordingService()
                .WithAllNAudioServices()
                .Build();
            container
                .KenkuVoiceTextParserService
                .SetKenkuEmulationData(new List<IReadOnlyVoiceRecording>()
                {
                    new VoiceRecording()
                    {
                        Id = Guid.NewGuid(),
                        PersonalityId = Guid.NewGuid(),
                        StreamType = Kenku.Enums.StreamType.MP3,
                        Text = "My name is"
                    },
                    new VoiceRecording()
                    {
                        Id = Guid.NewGuid(),
                        PersonalityId = Guid.NewGuid(),
                        StreamType = Kenku.Enums.StreamType.MP3,
                        Text = "Adam Patterson"
                    },
                    new VoiceRecording()
                    {
                        Id = Guid.NewGuid(),
                        PersonalityId = Guid.NewGuid(),
                        StreamType = Kenku.Enums.StreamType.MP3,
                        Text = "Do you like"
                    },
                    new VoiceRecording()
                    {
                        Id = Guid.NewGuid(),
                        PersonalityId = Guid.NewGuid(),
                        StreamType = Kenku.Enums.StreamType.MP3,
                        Text = "Pizza"
                    }
                });
            var parts = container
                .KenkuVoiceTextParserService
                .Parse("Hello! My name is Bob. Adam Patterson asked me, \"Do you like pizza?\". I do|not like it.");
            Assert.AreEqual("Hello!", parts[0].Text);
            Assert.AreEqual("My name is", parts[1].Text);
            Assert.AreEqual("My name is", parts[1].VoiceRecording?.Text);
            Assert.AreEqual("Bob.", parts[2].Text);
            Assert.AreEqual("Adam Patterson", parts[3].Text);
            Assert.AreEqual("Adam Patterson", parts[3].VoiceRecording?.Text);
            Assert.AreEqual("asked me, \"", parts[4].Text);
            Assert.AreEqual("Do you like", parts[5].Text);
            Assert.AreEqual("Do you like", parts[5].VoiceRecording?.Text);
            Assert.AreEqual("pizza", parts[6].Text);
            Assert.AreEqual("Pizza", parts[6].VoiceRecording?.Text);
            Assert.AreEqual("?\". I do", parts[7].Text);
            Assert.AreEqual("not like it.", parts[8].Text);
        }
    }
}