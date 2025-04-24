using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using GuvnorNnannaProject1.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;


namespace TestProject1
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var logger = NullLogger<HomeController>.Instance;
            var controller = new HomeController(logger);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void MassConversion_ValidInput_ReturnsConvertedValue()
        {
            // Arrange
            var logger = NullLogger<HomeController>.Instance;
            var controller = new HomeController(logger);

            // Act
            var result = controller.MassConversion("10") as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(22.0462, (double)result.ViewData["Pounds"], 3);
        }

        [Fact]
        public void MassConversion_InvalidInput_ReturnsErrorMessage()
        {
            // Arrange
            var logger = NullLogger<HomeController>.Instance;
            var controller = new HomeController(logger);

            // Act
            var result = controller.MassConversion("abc") as ViewResult;

            // Assert 
            Assert.NotNull(result);
            Assert.Equal("Invalid input. Please enter a numeric value.", result.ViewData["Error"]);
        }
    }
}
