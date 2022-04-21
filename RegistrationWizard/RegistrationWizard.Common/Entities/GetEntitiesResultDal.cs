namespace RegistrationWizard.Common.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Common;

    public class GetEntitiesResultDal<TEntity> : BaseEntityResult
    {
        public GetEntitiesResultDal(OperationResultCode result, IReadOnlyCollection<TEntity> entities, ErrorCode? errorCode)
            : base(result, errorCode)
        {
            Entities = entities;
        }

        public IReadOnlyCollection<TEntity> Entities { get; init; }

        public static GetEntitiesResultDal<TEntity> OfSuccess(IReadOnlyCollection<TEntity> entities) =>
            new(OperationResultCode.Success, entities, null);

        public static GetEntitiesResultDal<TEntity> OfError(OperationResultCode error, ErrorCode? errorType = null)
        {
            if (error == OperationResultCode.Success)
            {
                throw new InvalidEnumArgumentException(
                    nameof(error),
                    (int)OperationResultCode.Success,
                    typeof(OperationResultCode));
            }

            return new(error, Array.Empty<TEntity>(), errorType);
        }
    }
}