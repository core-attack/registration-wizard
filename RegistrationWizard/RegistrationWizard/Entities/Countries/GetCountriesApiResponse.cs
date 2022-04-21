namespace RegistrationWizard.Entities.Countries
{
    using System.Collections.Generic;

    public record GetCountriesApiResponse(IReadOnlyCollection<CountryApiEntity> Countries);
}
