using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using CarDataApi.Repository.Sql;
using CarDataApi.Service;
using CarDataApi.Service.DependantInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic.CompilerServices;
using CarDataApi.Service.Implementation;

namespace CarDataAPI.Web
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
            services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddTransient<ICarDataService, CarDataService>();
            services.AddTransient<ICarDataRepository,CarDataRepository>();

            services.AddDbContextPool<AppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CarDBConnection"), 
                    x => x.MigrationsAssembly("CarDataApi.Repository.Sql")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo{Title = "Car Data API",Version = "v1"});
            });
            services.AddControllers();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowEverything");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Car Data API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
