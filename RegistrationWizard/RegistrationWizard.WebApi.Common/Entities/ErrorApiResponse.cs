namespace RegistrationWizard.WebApi.Common.Entities
{
    using RegistrationWizard.Common;

    public class ErrorApiResponse
    {
        public ErrorApiResponse(ErrorCode? errorCode)
        {
            Error = new Error(errorCode ?? ErrorCode.Unknown);
        }

        public Error Error { get; init; }
    }
}
