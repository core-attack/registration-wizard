namespace RegistrationWizard
{
    using Autofac;
    using Common.Configuration;
    using Core.Dal.Configuration;
    using Dal;
    using Dal.Configuration;
    using Microsoft.Extensions.Configuration;

    public class RegistrationWizardAutofacModule : Module
    {
        private readonly IConfiguration configuration;

        public RegistrationWizardAutofacModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var dbContextConfigInstance = configuration.GetRequired<RegistrationWizardDbContextConfiguration>(RegistrationWizardDbContextConfiguration.SectionName);
            builder.RegisterInstance<IDbContextConfig>(dbContextConfigInstance);

            builder.RegisterModule(new RegistrationWizardDalAutofacModule());

        }
    }
}
