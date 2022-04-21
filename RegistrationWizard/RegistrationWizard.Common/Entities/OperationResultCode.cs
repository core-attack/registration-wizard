namespace RegistrationWizard.Common.Entities
{
    public enum OperationResultCode
    {
        /// <summary>
        /// Operation was completed successfully.
        /// </summary>
        Success,

        /// <summary>
        /// Operation cannot be completed because entity data is invalid.
        /// </summary>
        BadRequest
    }
}
