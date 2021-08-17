using Application.WebApi.Logging.ErrorCodeGenerator;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.Logging.Helpers
{
    public class LogHelper: ILogHelper
    {
        private readonly ILogger<LogHelper> logger;
        private readonly IErrorCodeGenerator errorCodeGenerator;

        public LogHelper(ILogger<LogHelper> logger, IErrorCodeGenerator errorCodeGenerator)
        {
            this.logger = logger;
            this.errorCodeGenerator = errorCodeGenerator;
        }

        public void LogInformation(string message)
        {
            logger.LogInformation($"EVENT: {message}");
        }

        public string LogError(Exception exception)
        {
            var errorCode = errorCodeGenerator.GenerateErrorCode();
            logger.LogError(exception, errorCode);
            return errorCode;
        }
    }
}
