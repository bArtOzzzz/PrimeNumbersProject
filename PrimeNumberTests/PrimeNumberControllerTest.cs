using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PrimeNumbersProject.Controllers;
using Service.Abstract;

namespace PrimeNumberTests
{
    public class PrimeNumberControllerTest
    {

        protected readonly Mock<IIsPrimeNumberService> _mockIsPrimeNumberService;

        protected readonly PrimeNumberController _primeNumberController;

        public PrimeNumberControllerTest()
        {
            _mockIsPrimeNumberService = new Mock<IIsPrimeNumberService>();

            _primeNumberController = new PrimeNumberController(_mockIsPrimeNumberService.Object);
        }

        //___________________________________Create_Async_____________________________________
        [Fact]
        public async void CreateAsync_OnSuccess_Return_Ok()
        {
            // Arrange
            _mockIsPrimeNumberService.Setup(config => config.CreateNumberAsync(It.IsAny<int>()))
                                                            .ReturnsAsync(true);

            // Act
            var result = (ObjectResult)await _primeNumberController.IsThisAPrimeNumber(It.IsAny<int>());

            // Assert
            result.Value.Should().BeEquivalentTo("This number is prime");
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void CreateAsync_WhenNumberIsNonPrime_Return_BadRequest()
        {
            // Arrange
            _mockIsPrimeNumberService.Setup(config => config.CreateNumberAsync(It.IsAny<int>()))
                                                            .ReturnsAsync(false);

            // Act
            var result = (ObjectResult)await _primeNumberController.IsThisAPrimeNumber(It.IsAny<int>());

            // Assert
            result.Value.Should().BeEquivalentTo("This number is non-prime");
            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}