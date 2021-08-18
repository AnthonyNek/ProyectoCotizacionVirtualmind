using Applicaction.Services;
using Application.Dto;
using Application.WebApi.Logging.Helpers;
using Application.WebApi.Util;
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
    public class ShoppingController : BaseController
    {
        private readonly ILogger<ShoppingController> log;
        protected readonly IConfiguration _configuration;
        public ShoppingController(IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<ShoppingController> log) : base(unitOfWork)
        {
            _configuration = configuration;
            quoteApi = new ApiConsumptionDolar(_configuration);
            this.log = log;
        }
        public IApiConsumptionDolar quoteApi { get; set; }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] DtoShopping dtoShopping)
        {
            try
            {
                if (dtoShopping.Amount <= 200 && dtoShopping.IdentificatorOfMoney == CurrencyType.Dolar)
                {
                    var resultado = await ResultSave(quoteApi, dtoShopping);
                    if (resultado > 0)
                    {
                        return Ok(new { resultado = "0000", Descripcion = "Transaccion Exitosa" });
                    }
                    else
                    {
                        return BadRequest(new { resultado = "1111", Descripcion = "Error al procesar la trasanccion" });
                    }
                }
                else if (dtoShopping.Amount <= 300 && dtoShopping.IdentificatorOfMoney == CurrencyType.Real)
                {
                    var resultado = await ResultSave(quoteApi, dtoShopping);
                    if (resultado > 0)
                    {
                        return Ok(new { resultado = "0000", Descripcion = "Transaccion Exitosa" });
                    }
                    else
                    {
                        return BadRequest(new { resultado = "1111", Descripcion = "Error al procesar la trasanccion" });
                    }
                }
                else
                {
                    return BadRequest(new { resultado = "1111", Descripcion = "Error al ingresar el valor o el tipo de moneda" });
                }

            }
            catch (Exception ex)
            {
                this.log.LogError(ex.Message);
                return BadRequest(new { resultado = "1111", Descripcion = "Error al procesar la trasanccion " + ex.Message });
            }
        }
        private async Task<int> ResultSave(IApiConsumptionDolar quoteApi,DtoShopping dtoShopping)
        {
            var result = await quoteApi.GetApiAsync(dtoShopping.IdentificatorOfMoney);
            dtoShopping.Amount = dtoShopping.Amount / Convert.ToDouble(result.Amount);
            int resultado = await _unitOfWork.shoppingService.Save(dtoShopping);
            return resultado;
        }
    }
}
