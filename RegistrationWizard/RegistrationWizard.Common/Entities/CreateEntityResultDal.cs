namespace RegistrationWizard.Common.Entities
{
    using System.ComponentModel;
    using Common;

    public class CreateEntityResultDal<TEntity> : BaseEntityResult
    {
        public CreateEntityResultDal(OperationResultCode result, TEntity? entity, ErrorCode? errorCode)
            : base(result, errorCode)
        {
            Entity = entity;
        }

        public TEntity? Entity { get; init; }

        public static CreateEntityResultDal<TEntity> OfSuccess(TEntity entity) => new (OperationResultCode.Success, entity, null);

        public static CreateEntityResultDal<TEntity> OfError(OperationResultCode error, ErrorCode? errorCode = null)
        {
            if (error == OperationResultCode.Success)
            {
                throw new InvalidEnumArgumentException(
                    nameof(error),
                    (int)OperationResultCode.Success,
                    typeof(OperationResultCode));
            }

            return new(error, default, errorCode);
        }
    }
}