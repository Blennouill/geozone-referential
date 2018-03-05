using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<StartupDevelopment>()
                .UseKestrel(options => options.AddServerHeader = false) // cf https://jeremylindsayni.wordpress.com/2016/12/22/creating-a-restful-web-api-template-in-net-core-1-1-part-4-securing-the-service-against-xss-clickjacking-and-drive-by-downloads/ https://securityheaders.io/
                .Build();
    }
}