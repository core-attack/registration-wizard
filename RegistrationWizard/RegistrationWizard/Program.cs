namespace RegistrationWizard
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using System.Threading.Tasks;
    using Core.Dal.Extensions;
    using Dal.DbContext;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Serilog;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.MigrateAsync<RegistrationWizardDbContext>();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                        .Build();

                    builder.AddConfiguration(configuration);
                })
                .UseSerilog((c, config) =>
                {
                    config
                        .ReadFrom
                        .Configuration(c.Configuration)
                        .Enrich
                        .WithProperty(Core.Logging.Logger.LogTypeIndexName, Core.Logging.Logger.ApplicationLogTypeName);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
