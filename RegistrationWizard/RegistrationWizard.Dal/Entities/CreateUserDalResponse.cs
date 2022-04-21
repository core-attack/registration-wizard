namespace RegistrationWizard.Dal.Entities
{
    public record CreateUserDalResponse(long Id, string Login, string Country, string Province, bool IsAgreeToWorkForFood);
}
