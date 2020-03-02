using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace SwaggerTest.api
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
            services.AddSwaggerGen(options =>
            {
                options.IgnoreObsoleteActions();
                options.IgnoreObsoleteProperties();
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Api version1",
                    Version = "v2",
                    Description = "An API to perform Employee operations",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Esty",
                        Email = "esty_c@hotmail.com",
                        Url = new Uri("https://twitter.com/jwalkner"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Open Api License",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                ///options.DocumentFilter();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "netcore swagger test";
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
                options.InjectStylesheet("/custom-swagger-ui.css");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}