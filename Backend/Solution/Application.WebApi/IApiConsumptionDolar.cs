using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi
{
     public interface IApiConsumptionDolar
    {
        Task<ResultApi> GetApiAsync(string currencyIdentifier);
    }
}
