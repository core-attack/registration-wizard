namespace RegistrationWizard.Dal.DbContext
{
    using Autofac;
    using Core.Dal.Configuration;
    using Core.Dal.DbContext;
    using DbModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using ILogger = Core.Logging.ILogger;

    public class RegistrationWizardDbContext : BaseDbContext<RegistrationWizardDbContext>
    {
        private const string DefaultSchemaName = "configuration";

        public RegistrationWizardDbContext(
            IDbContextConfig config,
            ILifetimeScope lifetimeScope,
            ILogger logger,
            ILoggerFactory loggerFactory)
            : base(config, lifetimeScope, logger, loggerFactory)
        {
        }

        public virtual DbSet<CountryDb> Countries => Set<CountryDb>();

        public virtual DbSet<UserDb> Users => Set<UserDb>();

        public virtual DbSet<ProvinceDb> Provinces => Set<ProvinceDb>();

        public override string SchemaName => DefaultSchemaName;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDb>()
                .HasOne(e => e.Province)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.ProvinceId);

            modelBuilder.Entity<ProvinceDb>()
                .HasOne(e => e.Country)
                .WithMany(e => e.Provinces)
                .HasForeignKey(e => e.CountryId);
        }
    }
}
