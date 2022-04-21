namespace RegistrationWizard.Dal.Mapping
{
    using DbContext.DbModels;
    using Entities;

    public static class UserMapper
    {
        public static CreateUserDalResponse Map(UserDb source) => new CreateUserDalResponse(source.Id, source.Login, source.Province.Name, source.Province.Country.Name, source.IsAgreeToWorkForFood);
    }
}
