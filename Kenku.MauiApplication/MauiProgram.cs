using Kenku.ElevenLabs;
using Kenku.Extensions;
using Kenku.GoogleCloudVoice;
using Kenku.Id3Tags;
using Kenku.MauiApplication.Helpers;
using Kenku.MauiApplication.Services.Implementations;
using Kenku.MauiApplication.ViewModels;
using Kenku.MauiApplication.Views;
using Kenku.MicrosoftTextToSpeech;
using Microsoft.Extensions.Logging;

namespace Kenku.MauiApplication;

public static class MauiProgram
{
    public static async Task<MauiApp> CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

#if DEBUG
        builder
            .Logging
            .AddDebug();
#endif

        var configurationService = new FilePersistenceExtendedConfigurationService(ConfigurationHelpers.GetOrCreateConfigurationFile());
        var container = ServiceFactory
            .CreateContainer()
            .WithConfigurationService(configurationService)
            .WithDefaultSerializerService()
            .WithDefaultPersonalityService()
            .WithDefaultAudioResourceService()
            .WithId3TagVoiceRecordingService()
            .WithAllNAudioServices()
            .Build();

        container
            .AddKenkuTextToSpeechService();
        container
            .AddMicrosoftTextToSpeechServices();

        if (!string.IsNullOrWhiteSpace(configurationService.ElevenLabsKey))
        {
            await container
                .AddEleventLabsTextToSpeechServicesAsync(configurationService.ElevenLabsKey)
                .ConfigureAwait(false);
        }

        var googleCloudConfigurationFile = new FileInfo(configurationService.GoogleCloudConfigurationFilePath);
        if (googleCloudConfigurationFile.Exists)
        {
            await container
                .AddGoogleCloudVoiceTextToSpeechServices(new FileInfo(configurationService.GoogleCloudConfigurationFilePath))
                .ConfigureAwait(false);
        }

        builder
            .Services
            .AddSingleton(container.AudioResourceService)
            .AddSingleton(container.ConfigurationService)
            .AddSingleton(container.KenkuEmulationService)
            .AddSingleton(container.KenkuVoiceTextParserService)
            .AddSingleton(container.PersonalityService)
            .AddSingleton(container.SerializerService)
            .AddSingleton(container.VoiceRecordingOperationsService)
            .AddSingleton(container.VoiceRecordingService)
            .AddSingleton<AppShell>();

        foreach (var service in container.TextToSpeechServices)
        {
            builder
                .Services
                .AddSingleton(service);
        }

        foreach (var service in container.InputAudioDeviceServices)
        {
            builder
                .Services
                .AddSingleton(service);
        }

        foreach (var service in container.OutputAudioDeviceServices)
        {
            builder
                .Services
                .AddSingleton(service);
        }

        var session = await container
            .CreateSessionAsync();
        builder
            .Services
            .AddSingleton(session);

        // Register your ViewModels and Pages
        builder
            .Services
            .AddTransient<MainViewModel>()
            .AddTransient<MainPage>();

        return builder
            .Build();
    }
}