namespace RegistrationWizard.WebApi.Common.Extensions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class SwaggerHelper
    {
        private static readonly string SwaggerVersion = "1.0";
        private static readonly string SwaggerEndpointUrl = "/swagger/1.0/swagger.json";

        public static void AddCustomSwagger(this IServiceCollection services, IConfiguration configuration, string swaggerTitle)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerVersion, new OpenApiInfo { Title = swaggerTitle, Version = SwaggerVersion });

                var entryAssembly = Assembly.GetEntryAssembly();

                if (entryAssembly != null)
                {
                    var xmlDocs = entryAssembly.GetReferencedAssemblies()
                        .Union(new AssemblyName[] { entryAssembly.GetName() })
                        .Select(a => Path.Combine(AppContext.BaseDirectory, $"{a.Name}.xml"))
                        .Where(File.Exists).ToArray();

                    Array.ForEach(xmlDocs, (d) =>
                    {
                        c.IncludeXmlComments(d);
                    });
                }
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, string swaggerName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerEndpointUrl, swaggerName);
            });
        }
    }
}
