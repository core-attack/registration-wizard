namespace RegistrationWizard.Mapping
{
    using Dal.Entities;
    using Entities.Users;

    public static class UserMapper
    {
        public static CreateUserDalRequest Map(CreateUserApiRequest source) => new CreateUserDalRequest( source.Login, source.Password, source.ProvinceId, source.IsAgreeToWorkForFood);

        public static CreateUserApiResponse Map(CreateUserDalResponse source) => new CreateUserApiResponse(source.Id, source.Login, source.Country, source.Province, source.IsAgreeToWorkForFood);

    }
}
