namespace RegistrationWizard.Common.Entities
{
    public class BaseEntityResult
    {
        public BaseEntityResult(OperationResultCode result, ErrorCode? errorCode)
        {
            Result = result;
            ErrorCode = errorCode;
        }

        public OperationResultCode Result { get; init; }

        public ErrorCode? ErrorCode { get; init; }
    }
}
