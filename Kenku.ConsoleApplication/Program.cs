// See https://aka.ms/new-console-template for more information
using Kenku;
using Kenku.ConsoleApplication.Models.Implementations;
using Kenku.Id3Tags;
using Kenku.Models.Implementations;
using Kenku.Services.Implementations;

Console.WriteLine("Hello, World!");

var container = ServiceFactory
    .CreateContainer()
    .WithAssetDirectoryPath(new DirectoryInfo(@"C:\Users\Admin\Desktop\VoiceAssets"))
    .WithDefaultSerializerService()
    .WithDefaultPersonalityService()
    .WithDefaultAudioResourceService()
    .WithId3TagVoiceRecordingService()
    .WithVoiceRecordingOperationsService(null)
    .AddInputAudioDeviceServices([])
    .AddOutputAudioDeviceServices([])
    .Build();

var voiceRecordingService = (Id3TagVoiceRecordingService)container.VoiceRecordingService;

var customVoicesContent = File
    .ReadAllText(@"C:\Users\Admin\Documents\KenkuVoices\WoodWater3\CustomVoices.json");
var customVoices = container
    .SerializerService
    .Deserialize<List<CustomVoice>>(customVoicesContent);
var catchPhrasesContent = File
    .ReadAllText(@"C:\Users\Admin\Documents\KenkuVoices\WoodWater3\Phrases.json");
var phrases = container
    .SerializerService
    .Deserialize<List<CatchPhrase>>(catchPhrasesContent);
foreach (var phrase in phrases)
{
    var voice = customVoices
        .FirstOrDefault(x => string.Equals(x.Name, phrase.Voice, StringComparison.OrdinalIgnoreCase));
    if (voice == null)
    {
        continue;
    }
    var oldFile = new FileInfo(@$"C:\Users\Admin\Documents\KenkuVoices\WoodWater3\{voice.FilePath}");
    try
    {
        //voiceRecordingService
        //    .Save(new VoiceRecording()
        //    {
        //        Id = Guid.Parse(voice.FilePath.Split('.')[0]),
        //        PersonalityId = Guid.Empty,
        //        StreamType = Kenku.Enums.StreamType.MP3,
        //        Text = phrase.Phrase
        //    }, oldFile);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(oldFile.FullName);
    }
}