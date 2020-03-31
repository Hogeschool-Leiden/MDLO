using System.Collections.Generic;
using System.Reflection;
using Demo.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.Api.Test
{
    [TestClass]
    public class WeatherForecastControllerTest
    {
        private ILogger<WeatherForecastController> _loggerStub;
        private Mock<IDateTimeProvider> _dateTimeProviderFake;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _loggerStub = new NullLogger<WeatherForecastController>();
            _dateTimeProviderFake = new Mock<IDateTimeProvider>();
        }
        
        [TestMethod]
        public void Get_Should_Return_Typeof_IEnumerable_Of_WeatherForecast()
        {
            // Arrange
            var controller = new WeatherForecastController(_loggerStub, _dateTimeProviderFake.Object);
            
            // Act
            var result = controller.Get();
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<WeatherForecast>));
        }

        [TestMethod]
        public void Should_Have_RouteAttribute()
        {
            // Arrange
            var controllerType = typeof(WeatherForecastController);
            
            // Act
            var result = controllerType.GetCustomAttribute<RouteAttribute>();
            
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Have_ApiControllerAttribute()
        {
            // Arrange
            var controllerType = typeof(WeatherForecastController);

            // Act
            var result = controllerType.GetCustomAttribute<ApiControllerAttribute>();
            
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_Should_Have_HttpGetAttribute()
        {
            // Arrange
            var controllerType = typeof(WeatherForecastController);
            var methodType = controllerType.GetMethod(nameof(WeatherForecastController.Get));
            
            // Act
            var result = methodType?.GetCustomAttribute<HttpGetAttribute>();
            
            // Assert
            Assert.IsNotNull(result);
        }
    }
}