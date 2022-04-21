namespace RegistrationWizard.Entities.Users
{
    public record CreateUserApiRequest(string Login, string Password, long ProvinceId, bool IsAgreeToWorkForFood);
}
