using System;
using System.Collections.Generic;
using System.Linq;
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
        private Mock<IRandomProvider> _randomProviderFake;

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerStub = new NullLogger<WeatherForecastController>();
            _dateTimeProviderFake = new Mock<IDateTimeProvider>();
            _randomProviderFake = new Mock<IRandomProvider>();

            _dateTimeProviderFake.Setup(stub => stub.Now).Returns(new DateTime(2020, 3, 11));
            _randomProviderFake
                .Setup(fake => fake.Next(It.IsAny<int>()))
                .Returns(2);

            _randomProviderFake
                .Setup(fake => fake.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(2);
        }

        [TestMethod]
        public void Get_Should_Return_Typeof_IEnumerable_Of_WeatherForecast()
        {
            // Arrange
            var controller = new WeatherForecastController(
                _loggerStub,
                _dateTimeProviderFake.Object,
                _randomProviderFake.Object
            );

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

        [TestMethod]
        public void Get_Should_Return_Any_Freezing_WeatherForecast_Given_The_Mocked_Random_Circumstances()
        {
            // Arrange
            var controller = new WeatherForecastController(
                _loggerStub,
                _dateTimeProviderFake.Object,
                _randomProviderFake.Object
            );

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsTrue(result.Any(forecast => forecast.Summary.Equals("Freezing")));
        }
    }
}