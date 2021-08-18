using Application.WebApi.Controllers;
using Application.WebApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Application.WebApi.Contoller.Mock
{
    public class QuoteControllerMock
    {
        private readonly Mock<ILogger<QuoteController>> loggerMock;
        public QuoteControllerMock()
        {
            loggerMock = new Mock<ILogger<QuoteController>>();
        }
        [Fact]
        public async Task Get_Returns_QuotesAsync()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();

            IConfiguration config = builder.Build();

            QuoteController quoteController = new(config, loggerMock.Object);
            var result = await quoteController.GetQuote(CurrencyType.Dolar);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
