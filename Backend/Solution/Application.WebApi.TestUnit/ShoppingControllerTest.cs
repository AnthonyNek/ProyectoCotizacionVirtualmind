using Applicaction.Services;
using Application.Dto;
using Application.WebApi.Controllers;
using Application.WebApi.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Application.WebApi.TestUnit
{
    public class ShoppingControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task Save_NotNull()
        {
           var  unitOfWorkMock = new Mock<IUnitOfWork>();
          var  logger = new Mock<ILogger<ShoppingController>>(){ CallBase = true };
            var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddEnvironmentVariables();

            IConfiguration config = builder.Build();
            var  shoppingController = new ShoppingController(unitOfWorkMock.Object, config, logger.Object);
            DtoShopping dtoShopping = new DtoShopping();
            dtoShopping.IdentificatorOfMoney = CurrencyType.Real;
            dtoShopping.Amount = 100;
            unitOfWorkMock.Setup(x => x.shoppingService.Save(dtoShopping)).ReturnsAsync(1);
            var result = await shoppingController.Save(dtoShopping);
            Assert.NotNull(result);
        }
    }
}
