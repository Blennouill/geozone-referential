using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Domain.Services;
using GeoZoneReferential.Domain.Shared.Interfaces;
using GeoZoneReferential.Infrastructure.Data;
using GeoZoneReferential.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace GeoZoneReferential.Interface
{
    /// <summary>
    /// Base start up class
    /// </summary>
    public abstract class StartupCommun
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration"></param>
        protected StartupCommun(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        /// <summary>
        /// Buil the serivces to inject
        /// </summary>
        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, GeoZoneReferentialContext>();

            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));

            services.AddMemoryCache();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Geozone Referential API",
                    Version = "v1"
                });
            });
        }

        /// <summary>
        /// Configue the pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "API Documentation";
                c.RoutePrefix = "api/docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geozone Referential API");
            });

            app.UseMvc();
        }
    }
}