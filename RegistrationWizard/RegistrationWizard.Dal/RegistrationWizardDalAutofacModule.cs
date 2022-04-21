namespace RegistrationWizard.Dal
{
    using Autofac;
    using Configuration;
    using Core.Dal.Configuration;
    using DbContext;
    using Providers;
    using RegistrationWizard.Core.Dal.Extensions;

    public class RegistrationWizardDalAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterConfiguration<RegistrationWizardDbContextConfiguration>(RegistrationWizardDbContextConfiguration.SectionName)
                .As<IDbContextConfig>();

            builder.RegisterDbContext<RegistrationWizardDbContext>();

            builder.RegisterType<RegistrationWizardDbContext>().AsSelf();
            builder.RegisterType<UsersDbDataProvider>().As<IUsersDbDataProvider>();
            builder.RegisterType<CountriesDbDataProvider>().As<ICountriesDbDataProvider>();
        }
    }
}
