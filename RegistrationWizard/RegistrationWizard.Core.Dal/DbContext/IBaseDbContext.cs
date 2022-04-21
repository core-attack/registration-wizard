namespace RegistrationWizard.Core.Dal.DbContext
{
    using Autofac;
    using Microsoft.Extensions.Logging;
    using ILogger = Core.Logging.ILogger;

    public interface IBaseDbContext
    {
        ILifetimeScope LifetimeScope { get; }

        ILogger Logger { get; }

        ILoggerFactory LoggerFactory { get; }

        string ConnectionString { get; }

        abstract string SchemaName { get; }

        virtual string MigrationsHistorySchemaName => SchemaName;
    }
}
