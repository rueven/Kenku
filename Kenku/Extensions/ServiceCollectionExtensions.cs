using Kenku.ServiceFactoryHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace Kenku.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IKenkuBuilderConfigurationService CreateKenkuBuilder(this IServiceCollection services)
        {
            return new KenkuBuilderConfigurationService();
        }
    }
}