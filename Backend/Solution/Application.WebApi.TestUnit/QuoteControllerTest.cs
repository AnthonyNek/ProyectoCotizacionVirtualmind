using Application.WebApi;
using Application.WebApi.Controllers;
using Application.WebApi.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TestPrueba3
{
    public class QuoteControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetQuote_NotNull()
        {
             var logger=  new  Mock<ILogger<QuoteController>>() ;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfiguration config = builder.Build();
            QuoteController quoteController = new(config, logger.Object);
            var result = await quoteController.GetQuote(CurrencyType.Dolar);
            Assert.IsNotNull(result);
        }
    }
}