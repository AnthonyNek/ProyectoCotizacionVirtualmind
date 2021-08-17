using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.Logging.Helpers
{
    public interface ILogHelper
    {
        void LogInformation(string message);

        string LogError(Exception e);
    }
}

