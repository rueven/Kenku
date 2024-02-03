using Kenku.WinformApplication.Services.Interfaces;
using Newtonsoft.Json;

namespace Kenku.WinformApplication.Services.Implementations
{
    internal class FilePersistenceExtendedConfigurationService : IExtendedConfigurationService
    {
        public FilePersistenceExtendedConfigurationService(FileInfo sourceFile)
        {
            this.SourceFile = sourceFile;
            this.LastUpdated = sourceFile
                .LastWriteTimeUtc;
        }

        private FileInfo SourceFile { get; }
        private DateTime LastUpdated { get; set; }
        private SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1);
        private IExtendedConfigurationService Service { get; set; }

        private void RefreshCacheAsRequired()
        {
            if (this.Service == null || this.SourceFile.LastAccessTimeUtc != this.LastUpdated)
            {
                this.Semaphore
                    .Wait(4);
                if (this.Service != null && this.SourceFile.LastAccessTimeUtc == this.LastUpdated)
                {
                    return;
                }
                var contents = File
                    .ReadAllText(this.SourceFile.FullName);
                var configurationService = JsonConvert
                    .DeserializeObject<ExtendedConfigurationService>(contents)!;
                this.Service = configurationService;
                this.LastUpdated = this
                    .SourceFile
                    .LastAccessTimeUtc;
                this.Semaphore
                    .Release();
            }
        }

        private T ReadValue<T>(Func<IExtendedConfigurationService, T> selector)
        {
            this.RefreshCacheAsRequired();
            var output = selector(this.Service);
            return output;
        }

        public void Save()
        {
            var content = JsonConvert
                .SerializeObject(this.Service, Formatting.Indented);
            File.WriteAllText(this.SourceFile.FullName, content);
            this.RefreshCacheAsRequired();
        }

        public string AssetDirectory
        {
            get => this.ReadValue(x => x.AssetDirectory);
            set => this.Service.AssetDirectory = value;
        }

        public string? OutputAudioDeviceServiceName
        {
            get => this.ReadValue(x => x.OutputAudioDeviceServiceName);
            set => this.Service.OutputAudioDeviceServiceName = value;
        }

        public string? PreviewAudioDeviceServiceName
        {
            get => this.ReadValue(x => x.PreviewAudioDeviceServiceName);
            set => this.Service.PreviewAudioDeviceServiceName = value;
        }

        public string? InputAudioDeviceServiceName
        {
            get => this.ReadValue(x => x.InputAudioDeviceServiceName);
            set => this.Service.InputAudioDeviceServiceName = value;
        }

        public string? ElevenLabsKey
        {
            get => this.ReadValue(x => x.ElevenLabsKey);
            set => this.Service.ElevenLabsKey = value;
        }

        public string? GoogleCloudConfigurationFilePath
        {
            get => this.ReadValue(x => x.GoogleCloudConfigurationFilePath);
            set => this.Service.GoogleCloudConfigurationFilePath = value;
        }

        public bool IsMirroredPlaybackMode
        {
            get => this.ReadValue(x => x.IsMirroredPlaybackMode);
            set => this.Service.IsMirroredPlaybackMode = value;
        }

        public bool MicrosoftTextToSpeechServicesEnabled
        {
            get => this.ReadValue(x => x.MicrosoftTextToSpeechServicesEnabled);
            set => this.Service.MicrosoftTextToSpeechServicesEnabled = value;
        }
        public bool MicrosoftSpeechToTextServiceEnabled
        {
            get => this.ReadValue(x => x.MicrosoftSpeechToTextServiceEnabled);
            set => this.Service.MicrosoftSpeechToTextServiceEnabled = value;
        }
        public bool IsPushToTalkEmulationEnabled
        {
            get => this.ReadValue(x => x.IsPushToTalkEmulationEnabled);
            set => this.Service.IsPushToTalkEmulationEnabled = value;
        }
        public string? PushToTalkKey
        {
            get => this.ReadValue(x => x.PushToTalkKey);
            set => this.Service.PushToTalkKey = value;
        }
    }
}