using Kenku.Services.Interfaces;

namespace Kenku.Objects.Implementations
{
    partial class Session
    {
        private IOutputAudioDeviceService InnerOutputAudioDeviceService;
        public IOutputAudioDeviceService OutputAudioDeviceService
        {
            get => this.InnerOutputAudioDeviceService;
            set
            {
                this.InnerOutputAudioDeviceService = value ?? throw new ArgumentNullException(nameof(value));
                this.Container.ConfigurationService.OutputAudioDeviceServiceName = value!.Name;
            }
        }

        private IOutputAudioDeviceService InnerPreviewAudioDeviceService;
        public IOutputAudioDeviceService PreviewAudioDeviceService
        {
            get => this.InnerPreviewAudioDeviceService;
            set
            {
                this.InnerPreviewAudioDeviceService = value ?? throw new ArgumentNullException(nameof(value));
                this.Container.ConfigurationService.PreviewAudioDeviceServiceName = value!.Name;
            }
        }

        private IInputAudioDeviceService InnerInputAudioDeviceService;
        public IInputAudioDeviceService InputAudioDeviceService
        {
            get => this.InnerInputAudioDeviceService;
            set
            {
                this.InnerInputAudioDeviceService = value ?? throw new ArgumentNullException(nameof(value));
                this.Container.ConfigurationService.InputAudioDeviceServiceName = value!.Name;
            }
        }
    }
}