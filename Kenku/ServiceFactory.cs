using Kenku.ServiceFactoryHelpers;

namespace Kenku
{
    public static class ServiceFactory
    {
        public static IKenkuBuilderConfigurationService CreateContainer()
        {
            return new KenkuBuilderConfigurationService();
        }
    }
}