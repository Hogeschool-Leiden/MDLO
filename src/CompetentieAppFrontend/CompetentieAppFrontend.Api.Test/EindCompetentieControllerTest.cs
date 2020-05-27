using CompetentieAppFrontend.Api.Controllers;
using CompetentieAppFrontend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Api.Test
{
    [TestClass]
    public class EindCompetentieControllerTest
    {
        private Mock<IEindCompetentieService> _eindCompetentieService;
        private Mock<ILogger<EindCompetentieController>> _loggerMock;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _eindCompetentieService = new Mock<IEindCompetentieService>();
            _loggerMock = new Mock<ILogger<EindCompetentieController>>();
        }
        
        
    }
}