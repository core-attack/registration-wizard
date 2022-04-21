namespace RegistrationWizard.Dal.Providers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Logging;
    using Common;
    using Common.Entities;
    using DbContext;
    using DbContext.DbModels;
    using Entities;
    using Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersDbDataProvider : IUsersDbDataProvider
    {
        private readonly ILogger _logger;

        private readonly RegistrationWizardDbContext _context;

        public UsersDbDataProvider(
            ILogger logger,
            RegistrationWizardDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<CreateEntityResultDal<CreateUserDalResponse>> CreateUserAsync(CreateUserDalRequest command, CancellationToken cancellationToken)
        {
            var province = await _context.Provinces.FirstOrDefaultAsync(x => x.Id == command.ProvinceId, cancellationToken);

            if (province == null)
            {
                return CreateEntityResultDal<CreateUserDalResponse>.OfError(OperationResultCode.BadRequest, ErrorCode.EntityNotFound);
            }

            var user = new UserDb
            {
                Login = command.Email,
                PasswordHash = PasswordHelper.HashPassword(command.Password),
                ProvinceId = province.Id,
                IsAgreeToWorkForFood = command.IsAgreeToWorkForFood
            };

            _context.Users.Add(user);

            try //todo refactor
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch(DbUpdateException)
            {
                return CreateEntityResultDal<CreateUserDalResponse>.OfError(OperationResultCode.BadRequest, ErrorCode.Unknown);
            }

            _logger.LogDebug("User {Email} successfully registered", user.Login);

            return CreateEntityResultDal<CreateUserDalResponse>.OfSuccess(UserMapper.Map(user));
        }
    }
}
