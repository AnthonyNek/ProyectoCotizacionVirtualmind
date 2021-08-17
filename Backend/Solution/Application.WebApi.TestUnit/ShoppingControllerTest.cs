using Applicaction.Services;
using Application.Dto;
using Application.WebApi.Controllers;
using Application.WebApi.Util;
using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var configurationMock = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
           var  unitOfWorkMock = new Mock<IUnitOfWork>();
          var  logger = new Mock<ILogger<ShoppingController>>(){ CallBase = true };
          var  shoppingController = new ShoppingController(unitOfWorkMock.Object, configurationMock.Object, logger.Object);
            DtoShopping dtoShopping = new DtoShopping();
            dtoShopping.IdentificatorOfMoney = CurrencyType.Real;
            dtoShopping.Amount = 100;

            var result = await shoppingController.Save(dtoShopping);
            Assert.NotNull(result);
        }
    }
}
