﻿using GeoZoneReferential.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeoZoneReferential.Interface
{
    /// <summary>
    /// Start up class used when env variable is define to "Development"
    /// </summary>
    public sealed class StartupDevelopment : StartupCommun
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration"></param>
        public StartupDevelopment(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Buil the serivces to inject
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            //services.AddDbContext<GeoZoneReferentialContext>(options => options.UseInMemoryDatabase("GeoZone"));
            services.AddDbContext<GeoZoneReferentialContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GeoZone")));
        }

        /// <summary>
        /// Configue the pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            base.Configure(app, env);
        }
    }
}