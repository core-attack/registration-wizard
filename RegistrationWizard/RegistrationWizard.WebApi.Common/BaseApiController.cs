namespace RegistrationWizard.WebApi.Common
{
    using System;
    using Entities;
    using Microsoft.AspNetCore.Mvc;
    using RegistrationWizard.Common;
    using RegistrationWizard.Common.Entities;
    using RegistrationWizard.Core.Logging;

    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public const string BaseApiUrlPath = "api";

        protected BaseApiController(ILogger logger)
        {
            this.Logger = logger;
        }

        protected ILogger Logger { get; }

        protected virtual IActionResult FromResultCode<T>(BaseEntityResult response, Func<object>? successResponseValueFunc = null) =>
            response.Result switch
            {
                OperationResultCode.Success => successResponseValueFunc != null ? Ok(successResponseValueFunc()) : Ok(),
                _ => Conflict(new ErrorApiResponse(response.ErrorCode))
            };
    }
}
