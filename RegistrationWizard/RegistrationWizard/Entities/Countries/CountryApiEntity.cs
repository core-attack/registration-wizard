namespace RegistrationWizard.Entities.Countries
{
    using System.Collections.Generic;

    public record CountryApiEntity(long Id, string Name, IReadOnlyCollection<ProvinceApiEntiry> Provinces);
}
