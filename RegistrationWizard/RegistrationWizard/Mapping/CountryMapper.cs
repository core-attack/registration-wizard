namespace RegistrationWizard.Mapping
{
    using System.Linq;
    using Dal.Entities;
    using Entities.Countries;

    public static class CountryMapper
    {
        public static GetCountriesDalRequest Map(GetCountriesApiRequest source) => new GetCountriesDalRequest(source.Page, source.PageSize);

        public static CountryApiEntity Map(CountryDalEntity source) => new CountryApiEntity(source.Id, source.Name, source.Provinces.Select(Map).ToList());

        public static ProvinceApiEntiry Map(ProvinceDalEntity source) => new ProvinceApiEntiry(source.Id, source.Name);
    }
}
