namespace RegistrationWizard.Core.Dal.Extensions
{
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Npgsql;

    public static class DbContextExtensions
    {
        public const string EnableStartupMigrationsKey = "EnableStartupMigrations";

        public static async ValueTask MigrateAsync<TContext>(this IHost host)
            where TContext : DbContext
        {
            var configuration = host.Services.GetRequiredService<IConfiguration>();

            if (!configuration.GetValue(EnableStartupMigrationsKey, false))
            {
                return;
            }

            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TContext>();
            await context.Database.MigrateAsync();
            var dbConnection = context.Database.GetDbConnection();
            if (dbConnection is NpgsqlConnection npgsqlConnection)
            {
                await npgsqlConnection.OpenAsync();
                npgsqlConnection.ReloadTypes();
            }
        }

        public static IRegistrationBuilder<TContext, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterDbContext<TContext>(this ContainerBuilder builder)
            where TContext : DbContext
            => builder.RegisterType<TContext>().AsSelf().InstancePerLifetimeScope();
    }
}
