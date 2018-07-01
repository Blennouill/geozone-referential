using Hangfire;
using Microsoft.Extensions.Configuration;
using System;

namespace GeoZoneReferential.Infrastructure.Externals.Hangfire
{
    /// <summary>
    /// Is used to provide contents configuration for Hangfire.
    /// </summary>
    public static class HangfireCustomConfigurationHelper
    {
        /// <summary>
        /// Is used to get the database configuration for Hangfire.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public static Action<IGlobalConfiguration> GetDbConfiguration(IConfiguration configuration)
        {
            return config => config.UseSqlServerStorage(configuration.GetConnectionString("Hangfire"));
        }
    }
}
