using Microsoft.Extensions.Configuration;
using System;

namespace Application.WebApi.Logging.ErrorCodeGenerator
{
    public class ErrorCodeGenerator : IErrorCodeGenerator
    {
        private readonly IConfiguration configuration;

        public ErrorCodeGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateErrorCode()
        {
            var code = configuration.GetValue<string>("PREFIX_ERROR_CODE");
            return $"{code}-{Guid.NewGuid()}";
        }
    }
}