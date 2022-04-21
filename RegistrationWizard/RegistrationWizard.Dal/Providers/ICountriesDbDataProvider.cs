namespace RegistrationWizard.Dal.Providers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Entities;
    using Entities;

    public interface ICountriesDbDataProvider
    {
        Task<GetEntitiesResultDal<CountryDalEntity>> GetCountriesAsync(GetCountriesDalRequest req, CancellationToken cancellationToken);
    }
}
