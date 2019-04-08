using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Education.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CV.Education
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string AllowApiGateway = "_AllowApiGateway";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(options =>
                options.AddPolicy(AllowApiGateway, builder =>
                    builder.WithOrigins(
                        // API Gateway
                        "https://localhost:6000",
                        // TODO: Remove
                        "https://localhost:5001"
                        )
                    )
                );

            services.AddDbContext<CVContext>(options =>
            // TODO: Reemplazar por JsonFile
            // https://docs.microsoft.com/es-es/aspnet/core/fundamentals/configuration/index?view=aspnetcore-2.2#json-configuration-provider
                options.UseSqlServer("Server=localhost;Database=CV;Trusted_Connection=True;")
                );

            services.AddTransient<IEducationRepository, EducationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(AllowApiGateway);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
