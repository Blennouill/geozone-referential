using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace GeoZoneReferential.Interface.Infrastructures.Middlewares
{
    /// <summary>
    /// Is used to regroup middleware declaration in the configuration pipeline.
    /// </summary>
    public static class ConfigureMiddlewareExtension
    {
        /// <summary>
        /// Enable the custom hangfire configuration in the pipeline.
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        public static IApplicationBuilder UseCustomHangfire(this IApplicationBuilder app)
        {
            return app  .UseHangfireDashboard()
                        .UseHangfireServer();
        }
    }
}
