using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using reservation_project.Store;
using Microsoft.Extensions.Options;
using reservation_project.services.interfaces;
using reservation_project.services;

namespace reservation_project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //add database
            services.Configure<TheaterstoreDatabaseSettings>(
                Configuration.GetSection(nameof(TheaterstoreDatabaseSettings)));
            services.AddSingleton<ITheaterstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<TheaterstoreDatabaseSettings>>().Value);

            services.AddControllers();

            services.AddTransient<IPlayService, PlayService>();
            services.AddTransient<IPlayStore, PlayStore>();
            services.AddTransient<ITheaterService, TheaterService>();
            services.AddTransient<ITheaterStore, TheaterStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
