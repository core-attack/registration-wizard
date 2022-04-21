namespace RegistrationWizard.Dal.Providers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Entities;
    using Entities;

    public interface IUsersDbDataProvider
    {
        Task<CreateEntityResultDal<CreateUserDalResponse>> CreateUserAsync(CreateUserDalRequest command, CancellationToken cancellationToken);
    }
}
