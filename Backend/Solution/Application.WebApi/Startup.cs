using Applicaction.Services;
using Application.Repositories.Models;
using Application.WebApi.Logging.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi
{
    public class Startup
    {
        private readonly string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork>(option => new UnitOfWork(new BDCompanyContext(new DbContextOptionsBuilder<BDCompanyContext>().UseSqlServer(Configuration.GetConnectionString("DefaultConnectionSqll")).Options)));
        
            //services.Scan(
            //     x =>
            //     {
            //         var referencedAssemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
            //         x.FromAssemblies(referencedAssemblies)
            //           .AddClasses(classes => classes.AssignableTo<ILogHelper>())
            //           .AsMatchingInterface()
            //           .WithTransientLifetime();
            //     }
            //     );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application.WebApi", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(Configuration.GetValue<string>("urlQuote"))
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application.WebApi v1"));
            }

            app.UseRouting();
            app.UseCors(myAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
