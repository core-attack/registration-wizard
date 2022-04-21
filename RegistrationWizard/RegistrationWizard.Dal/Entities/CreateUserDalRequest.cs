namespace RegistrationWizard.Dal.Entities
{
    public record CreateUserDalRequest(string Email, string Password, long ProvinceId, bool IsAgreeToWorkForFood);
}
