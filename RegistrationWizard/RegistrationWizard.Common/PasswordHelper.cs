namespace RegistrationWizard.Common
{
    using BCrypt.Net;

    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.HashPassword(password);
        }

        public static bool IsCorrect(string password, string passwordHash)
        {
            return BCrypt.Verify(password, passwordHash);
        }
    }
}
