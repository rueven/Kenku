using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Implementations;

namespace Kenku.Id3Tags
{
    public static class Id3TagExtensions
    {
        public static IKenkuBuilderVoiceRecordingOperationsService WithId3TagVoiceRecordingService(this IKenkuBuilderVoiceRecordingService builder)
        {
            return builder
                .WithVoiceRecordingService(new Id3TagVoiceRecordingService
                (
                    builder.AudioResourceService!,
                    builder.ConfigurationService!
                ));
        }
    }
}