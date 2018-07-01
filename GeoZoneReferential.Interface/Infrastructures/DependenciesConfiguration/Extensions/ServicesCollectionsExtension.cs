using GeoZoneReferential.Infrastructure.Externals.Hangfire;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeoZoneReferential.Interface.Infrastructures.DependenciesConfiguration.Extensions
{
    /// <summary>
    /// Is used to define regroupment of services declaration to inject in the DI configuration.
    /// </summary>
    public static class ServicesCollectionsExtension
    {
        public static IServiceCollection AddCustomHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddHangfire(HangfireCustomConfigurationHelper.GetDbConfiguration(configuration));
        }
    }
}
