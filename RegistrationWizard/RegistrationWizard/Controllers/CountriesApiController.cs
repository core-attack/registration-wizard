namespace RegistrationWizard.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Logging;
    using Dal.Providers;
    using Entities.Countries;
    using Mapping;
    using Microsoft.AspNetCore.Http;
    using WebApi.Common;

    [Route(BaseApiUrlPath + "/countries")]
    public class CountriesApiController : BaseApiController
    {
        private readonly ICountriesDbDataProvider _countriesProvider;

        public CountriesApiController(ILogger logger, ICountriesDbDataProvider countriesProvider) : base(logger)
        {
            _countriesProvider = countriesProvider;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetCountriesApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(GetCountriesApiRequest req, CancellationToken cancellationToken)
        {
            var dalModel = CountryMapper.Map(req);
            var dalResult = await _countriesProvider.GetCountriesAsync(dalModel, cancellationToken);
            return FromResultCode<GetCountriesApiResponse>(dalResult, () => dalResult.Entities.Select(CountryMapper.Map));
        }
    }
}
