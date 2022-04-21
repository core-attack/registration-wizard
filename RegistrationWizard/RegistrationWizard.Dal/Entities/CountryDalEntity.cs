namespace RegistrationWizard.Dal.Entities
{
    using System.Collections.Generic;

    public record CountryDalEntity(long Id, string Name, IReadOnlyCollection<ProvinceDalEntity> Provinces);
}
