using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Application.WebApi
{
    public class ApiConsumptionDolar: IApiConsumptionDolar
    {
        protected readonly IConfiguration _configuration;
        public ApiConsumptionDolar(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ResultApi> GetApiAsync(string currencyIdentifier)
        {
            string[] resp;
            ResultApi resultApi = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["urlQuote"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("Principal/Dolar");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    resp = JsonConvert.DeserializeObject<string[] > (result);
                    resultApi.Amount = currencyIdentifier == "Dolar" ? resp[0] : Convert.ToString(Convert.ToDouble(resp[0] )/ 4);
                }
              
            }
            return resultApi;
        }
    }
}
