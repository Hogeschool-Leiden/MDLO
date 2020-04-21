using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Demo.Api.IntegrationTest
{
    [TestClass]
    public class WeatherForecastControllerApiTest
    {
        private const string DefaultUrl = "http://localhost:5000/weatherforecast";
        private const string AppUrlEnvironmentName = "APP_URL";

        private static string _baseUrl;

        private HttpClient _httpClient;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context) =>
            _baseUrl = Environment.GetEnvironmentVariable(AppUrlEnvironmentName) ?? DefaultUrl;

        [TestInitialize]
        public void TestInitialize() => _httpClient = new HttpClient();

        [TestMethod]
        public async Task Get_Should_Result_In_HttpStatusCode_Of_200_Ok()
        {
            // Arrange
            var response = await _httpClient.GetAsync(_baseUrl);

            // Act
            var result = response.StatusCode;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, result);
        }

        [TestMethod]
        public async Task Get_Should_Return_Typeof_IEnumerable_Of_WeatherForecast()
        {
            // Arrange
            var response = await _httpClient.GetAsync(_baseUrl);

            // Act
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.IsNotNull(JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(result));
        }
    }
}
