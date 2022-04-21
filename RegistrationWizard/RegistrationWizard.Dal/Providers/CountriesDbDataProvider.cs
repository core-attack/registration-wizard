namespace RegistrationWizard.Dal.Providers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Entities;
    using Core.Logging;
    using DbContext;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class CountriesDbDataProvider : ICountriesDbDataProvider
    {
        private const int DefaultPageSize = 10;
        private readonly ILogger _logger;

        private readonly RegistrationWizardDbContext _context;

        public CountriesDbDataProvider(
            ILogger logger,
            RegistrationWizardDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<GetEntitiesResultDal<CountryDalEntity>> GetCountriesAsync(GetCountriesDalRequest req, CancellationToken cancellationToken)
        {
            var skip = req.Page < 0 ? 0 : req.Page * req.PageSize;
            var pageSize = req.PageSize <= 0 ? DefaultPageSize : req.PageSize;
            var countries = await _context.Countries
                .Include(x => x.Provinces)
                .Skip(skip)
                .Take(pageSize)
                .Select(x => new CountryDalEntity(
                    x.Id,
                    x.Name,
                    x.Provinces.Select(y => new ProvinceDalEntity(y.Id, y.Name)).ToList())
                ).ToListAsync(cancellationToken);


            _logger.LogDebug("{Count} countries fetched", countries.Count);

            return GetEntitiesResultDal<CountryDalEntity>.OfSuccess(countries);
        }
    }
}
