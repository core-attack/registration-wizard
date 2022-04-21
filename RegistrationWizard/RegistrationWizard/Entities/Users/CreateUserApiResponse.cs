namespace RegistrationWizard.Entities.Users
{
    public record CreateUserApiResponse(long Id, string Login, string Country, string Province, bool IsAgreeToWorkForFood);
}
