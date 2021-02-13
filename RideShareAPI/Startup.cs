using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RideShare.Business.Managers.Ride;
using RideShare.DataAccess;
using RideShare.DataAccess.Repository;
using RideShare.DataAccess.UnitOfWork;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareAPI
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
            services.AddControllers();

            services.AddDbContext<DatabaseContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection"),
                 x => x.MigrationsAssembly("RideShare.DataAccess")
                 ));

            services.AddTransient<IReservationManager, ReservationManager>();
            services.AddTransient<IRideManager, RideManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new OpenApiInfo
                {
                    
                    Title = "Ride Share Application",
                    Version = "1.0.0",
                    Description = "Adesso Test Case için hazırlanmıştır",
                    Contact = new OpenApiContact()
                    {
                        Name = "Ömer Çavuşlu",
                        Email = "omer.cavuslu@windowslive.com"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger()
           .UseSwaggerUI(c =>
           {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test .Net Core");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
