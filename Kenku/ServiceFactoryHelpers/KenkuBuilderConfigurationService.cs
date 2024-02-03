using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderConfigurationService : IKenkuBuilderConfigurationService
    {
        public IKenkuBuilderSerializerService WithConfigurationService(IConfigurationService configurationService)
        {
            return new KenkuBuilderSerializerService()
            {
                ConfigurationService = configurationService
            };
        }

        public IKenkuBuilderSerializerService WithAssetDirectoryPath(DirectoryInfo directory)
        {
            return new KenkuBuilderSerializerService()
            {
                ConfigurationService = new ConfigurationService()
                {
                    AssetDirectory = directory.FullName
                }
            };
        }
    }
}