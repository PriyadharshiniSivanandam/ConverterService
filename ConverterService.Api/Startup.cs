using System;
using System.IO;
using System.Reflection;
using ConverterService.ApplicationServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConverterService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization()
                .AddApiExplorer();

            services.AddTransient<DigitToRomanNumeralConverter>()
                    .AddTransient<RomanNumeralToDigitConverter>();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("Converter", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Converter.Api"
                });
                setupAction.IncludeXmlComments(GetXmlCommentsFilePath());
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger()
               .UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/Converter/swagger.json",
                        "Converter");
                    setupAction.RoutePrefix = ".docs";
                    setupAction.DocumentTitle = "Converter Api";
                    setupAction.SupportedSubmitMethods();
                    setupAction.DefaultModelsExpandDepth(-1);
                });

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private string GetXmlCommentsFilePath()
        {
            var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
        }
    }
}
