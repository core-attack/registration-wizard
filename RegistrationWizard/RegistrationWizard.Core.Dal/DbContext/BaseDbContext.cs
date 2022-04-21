namespace RegistrationWizard.Core.Dal.DbContext
{
    using Autofac;
    using Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using ILogger = Core.Logging.ILogger;

    public abstract class BaseDbContext<TDbContext> : DbContext, IBaseDbContext
       where TDbContext : BaseDbContext<TDbContext>
    {
        protected BaseDbContext(IDbContextConfig config, ILifetimeScope lifetimeScope, ILogger logger, ILoggerFactory loggerFactory)
        {
            this.LifetimeScope = lifetimeScope;
            this.ConnectionString = config.ConnectionString;

            this.Logger = logger;
            this.LoggerFactory = loggerFactory;
        }

        public ILifetimeScope LifetimeScope { get; }

        public ILogger Logger { get; }

        public ILoggerFactory LoggerFactory { get; }

        public string ConnectionString { get; }

        public abstract string SchemaName { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            this.OnConfiguringImplementation(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.OnModelCreatingImplementation(modelBuilder);
        }
    }
}
