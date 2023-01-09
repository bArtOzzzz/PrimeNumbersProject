using FluentAssertions;
using Moq;
using Repository.Abstract;
using Service;

namespace PrimeNumberTests
{
    public class PrimeNumberServiceTest
    {
        protected readonly Mock<IIsPrimeNumberRepository> _mockIIsPrimeNumberRepository;

        protected readonly IsPrimeNumberService _isPrimeNumberService;

        public PrimeNumberServiceTest()
        {
            _mockIIsPrimeNumberRepository = new Mock<IIsPrimeNumberRepository>();

            _isPrimeNumberService = new IsPrimeNumberService(_mockIIsPrimeNumberRepository.Object);
        }

        [Fact]
        protected async Task CreateAsync_OnSuccess_Return_True()
        {
            // Arrange
            int number = 3;

            _mockIIsPrimeNumberRepository.Setup(config => config.CreateNumberAsync(It.IsAny<int>()))
                                         .ReturnsAsync(true);

            // Act
            var result = await _isPrimeNumberService.CreateNumberAsync(number);

            // Assert
            result.Should().Be(true);
        }

        [Fact]
        protected async Task CreateAsync_WhenNonPrimeNumber_Return_False()
        {
            // Arrange
            int number = 10;

            _mockIIsPrimeNumberRepository.Setup(config => config.CreateNumberAsync(It.IsAny<int>()))
                                         .ReturnsAsync(true);

            // Act
            var result = await _isPrimeNumberService.CreateNumberAsync(number);

            // Assert
            result.Should().Be(false);
        }
    }
}
