using GeoZoneReferential.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GeoZoneReferential.Interface
{
    /// <summary>
    /// Initizialise the app
    /// </summary>
    public class Program
    {
        /// <summary>
        /// First entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<GeoZoneReferentialContext>();
                    DataFixturesSeeder.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<StartupDevelopment>()
                .UseKestrel(options => options.AddServerHeader = false) // cf https://jeremylindsayni.wordpress.com/2016/12/22/creating-a-restful-web-api-template-in-net-core-1-1-part-4-securing-the-service-against-xss-clickjacking-and-drive-by-downloads/ https://securityheaders.io/
                .Build();
    }
}