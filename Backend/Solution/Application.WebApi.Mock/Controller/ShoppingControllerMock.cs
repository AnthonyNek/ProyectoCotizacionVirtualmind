using Applicaction.Services;
using Application.Dto;
using Application.WebApi.Controllers;
using Application.WebApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.WebApi.Mock.Controller
{
     public  class ShoppingControllerMock
    {
        private readonly Mock<ILogger<ShoppingController>> loggerMock;
        private readonly Mock<IUnitOfWork> unitOfworkMock;
        public ShoppingControllerMock()
        {
            loggerMock = new Mock<ILogger<ShoppingController>>();
            unitOfworkMock = new Mock<IUnitOfWork>();
        }
        [Fact]
        public async Task Save_Returns_Async()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();

            IConfiguration config = builder.Build();

            ShoppingController shoppingController = new ShoppingController(unitOfworkMock.Object, config, loggerMock.Object);
            DtoShopping dtoShopping = new DtoShopping();
            dtoShopping.IdentificatorOfMoney = CurrencyType.Real;
            dtoShopping.Amount = 100;
            unitOfworkMock.Setup(x => x.shoppingService.Save(dtoShopping)).ReturnsAsync(1);
            var result = await shoppingController.Save(dtoShopping);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
