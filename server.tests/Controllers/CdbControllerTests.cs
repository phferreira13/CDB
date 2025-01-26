using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using cdbApp.Server.Controllers;
using cdbApp.Server.Interfaces;
using cdbApp.Server.Models;
using Microsoft.AspNetCore.Http;
using server.tests.Shared;

namespace server.tests.Controllers
{
    public class CdbControllerTests
    {
        private readonly Mock<ICdbService> _mockCdbService;
        private readonly CdbController _controller;

        public CdbControllerTests()
        {
            _mockCdbService = new Mock<ICdbService>();
            _controller = new CdbController(_mockCdbService.Object);
        }

        [Fact]
        public void Get_ShouldReturnBadRequest_WhenInitialValueIsLessThanOrEqualToZero()
        {
            // Act
            var result = _controller.Get(0, 12);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Initial value and months must be greater than 0", badRequestResult.Value);
        }

        [Fact]
        public void Get_ShouldReturnBadRequest_WhenMonthsIsLessThanOrEqualToZero()
        {
            // Act
            var result = _controller.Get(1000, 0);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Initial value and months must be greater than 0", badRequestResult.Value);
        }

        [Fact]
        public void Get_ShouldReturnOk_WhenParametersAreValid()
        {
            // Arrange
            var initialValue = 1000M;
            var months = 12;
            var tb = 0.15M;
            var cdi = 0.02M;
            var tax = 0.2M;

            var expectedFinalValue = CalcFunctions.CalculateFinalValue(initialValue, months, tb, cdi);
            var expectedFinalValueWithTax = CalcFunctions.CalculateFinalValueWithTax(expectedFinalValue, tax);

            _mockCdbService.Setup(s => s.GetTb()).Returns(tb);
            _mockCdbService.Setup(s => s.GetCdi()).Returns(cdi);
            _mockCdbService.Setup(s => s.GetTax(months)).Returns(tax);

            // Act
            var result = _controller.Get(initialValue, months);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var cdb = Assert.IsType<Cdb>(okResult.Value);
            Assert.Equal(initialValue, cdb.InitialValue);
            Assert.Equal(months, cdb.Months);
            Assert.Equal(expectedFinalValue, cdb.FinalValue);
            Assert.Equal(expectedFinalValueWithTax, cdb.FinalValueWithTax);
        }
    }
}
