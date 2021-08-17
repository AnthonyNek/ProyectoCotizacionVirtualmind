using Application.WebApi.Logging.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly ILogger<QuoteController> log;
        protected readonly IConfiguration _configuration;
        public QuoteController(IConfiguration configuration, ILogger<QuoteController> log)
        {
            _configuration = configuration;
            quoteApi = new ApiConsumptionDolar(_configuration);
            this.log = log;
        }
        public IApiConsumptionDolar quoteApi { get; set; }
         [HttpGet]
         [Route("GetQuote/{currencyIdentifier}")]
         public  async Task<IActionResult> GetQuote(string currencyIdentifier)
        {
            try
            {
                if (currencyIdentifier == "Dolar" || currencyIdentifier == "Real")
                {
                    var result = await quoteApi.GetApiAsync(currencyIdentifier);
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { error = "The currency identifier is invalid" });
                }
            }
            catch (Exception ex )
            {
                log.LogError(ex.Message);
                return BadRequest(new { error = "Error "+ex.Message });
            }
         
        
        }
        
    }
}
