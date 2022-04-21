namespace RegistrationWizard
{
    using System.Reflection;
    using Autofac;
    using Autofac.Features.AttributeFilters;
    using Core.Logging;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using WebApi.Common;
    using WebApi.Common.Extensions;

    public class Startup
    {
        private static readonly string SwaggerName = "RegistrationWizard.WebApi";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddCustomSwagger(Configuration, SwaggerName);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Logger>().As<Core.Logging.ILogger>().SingleInstance();

            var currentAssembly = Assembly.GetEntryAssembly()!;
            builder.RegisterAssemblyTypes(currentAssembly).Where(t => t.IsSubclassOf(typeof(BaseApiController))).WithAttributeFiltering();

            builder.RegisterModule(new RegistrationWizardAutofacModule(Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseCustomSwagger(SwaggerName);
        }
    }
}
