using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using CarRentalSystem.Services;
using Moq;
using System;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace CarRentalSystem.Tests.Services
{
    public class RentalServiceTests
    {
        private readonly Mock<IRentalRepository> _rentalRepositoryMock;
        private readonly Mock<ICarRepository> _carRepositoryMock;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly RentalService _rentalService;

        public RentalServiceTests()
        {
            _rentalRepositoryMock = new Mock<IRentalRepository>();
            _carRepositoryMock = new Mock<ICarRepository>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _rentalService = new RentalService(_rentalRepositoryMock.Object, _carRepositoryMock.Object, _customerRepositoryMock.Object);
        }

        [Fact]
        public void CalculateRentalPrice_PremiumCar_10Days_ReturnsCorrectPrice()
        {
            // Arrange
            var car = new Car { Id = 1, Make = "BMW", Model = "7 Series", Type = CarType.Premium };

            // Act
            var price = _rentalService.CalculateRentalPrice(car.Type, 10);

            // Assert
            Assert.Equal(3000, price);
        }

        [Fact]
        public void CalculateRentalPrice_SUVCar_9Days_ReturnsCorrectPrice()
        {
            // Arrange
            var car = new Car { Id = 2, Make = "Kia", Model = "Sorento", Type = CarType.SUV };

            // Act
            var price = _rentalService.CalculateRentalPrice(car.Type, 9);

            // Assert
            Assert.Equal(1290, price);
        }

        [Fact]
        public void CalculateRentalPrice_SmallCar_10Days_ReturnsCorrectPrice()
        {
            // Arrange
            var car = new Car { Id = 4, Make = "Seat", Model = "Ibiza", Type = CarType.Small };

            // Act
            var price = _rentalService.CalculateRentalPrice(car.Type, 10);

            // Assert
            Assert.Equal(440, price);
        }

        [Fact]
        public void CalculateExtraPrice_PremiumCar_2ExtraDays_ReturnsCorrectPrice()
        {
            // Arrange
            var car = new Car { Id = 1, Make = "BMW", Model = "7 Series", Type = CarType.Premium };

            // Act
            var price = _rentalService.CalculateExtraPrice(car.Type, 2);

            // Assert
            Assert.Equal(720, price);
        }

        [Fact]
        public void CalculateExtraPrice_SUVCar_1ExtraDay_ReturnsCorrectPrice()
        {
            // Arrange
            var car = new Car { Id = 3, Make = "Nissan", Model = "Juke", Type = CarType.SUV };

            // Act
            var price = _rentalService.CalculateExtraPrice(car.Type, 1);

            // Assert
            Assert.Equal(180, price);
        }
    }
}
