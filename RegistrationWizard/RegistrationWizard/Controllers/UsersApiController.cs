namespace RegistrationWizard.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Logging;
    using Dal.Providers;
    using Entities.Users;
    using Mapping;
    using Microsoft.AspNetCore.Http;
    using WebApi.Common;

    [Route(BaseApiUrlPath + "/users")]
    public class UsersApiController : BaseApiController
    {
        private readonly IUsersDbDataProvider _userProvider;

        public UsersApiController(ILogger logger, IUsersDbDataProvider userProvider) : base(logger)
        {
            _userProvider = userProvider;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(CreateUserApiRequest req, CancellationToken cancellationToken)
        {
            var dalModel = UserMapper.Map(req);
            var dalResult = await _userProvider.CreateUserAsync(dalModel, cancellationToken);
            return FromResultCode<CreateUserApiResponse>(dalResult, () => UserMapper.Map(dalResult.Entity));
        }
    }
}
