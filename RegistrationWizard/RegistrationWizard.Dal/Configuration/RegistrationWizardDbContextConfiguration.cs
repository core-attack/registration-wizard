namespace RegistrationWizard.Dal.Configuration
{
    using Core.Dal.Configuration;

    public class RegistrationWizardDbContextConfiguration : IDbContextConfig
    {
        public const string SectionName = "RegistrationWizardDbContextConfiguration";

        public string ConnectionString { get; set; } = string.Empty;
    }
}
