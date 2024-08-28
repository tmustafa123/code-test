using CarSpeedAPI.Controllers;
using CarSpeedAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Xunit;
using System.Collections.Generic;
using CarSpeedAPI.Entities;

public class CarSpeedControllerTests
{
    [Fact]
    public void GetAverageSpeed_ShouldReturnOkResult_WithListOfAverageSpeeds()
    {
        // Arrange
        var mockService = new Mock<ICarSpeedService>();
        mockService.Setup(s => s.GetCars()).Returns(new List<Car>
        {
            new Car { Name = "Car1", Speeds = new List<int> { 60, 70, 80, 90, 100 } },
            new Car { Name = "Car2", Speeds = new List<int> { 50, 60, 70, 80, 90 } }
        });

        mockService.Setup(s => s.GetAverageSpeed(It.IsAny<Car>())).Returns((Car car) => car.Speeds.Average());

        var controller = new CarSpeedController(mockService.Object);

        // Act
        var result = controller.GetAverageSpeed();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);
        Assert.Equal(2, returnValue.Count());
    }

    [Fact]
    public void GetAverageSpeed_ShouldReturnBadRequest_WhenNoCarsAreFound()
    {
        // Arrange
        var mockService = new Mock<ICarSpeedService>();
        mockService.Setup(s => s.GetCars()).Returns(new List<Car>());

        var controller = new CarSpeedController(mockService.Object);

        // Act
        var result = controller.GetAverageSpeed();

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void GetAverageSpeed_ShouldReturnBadRequest_WhenFileNotFound()
    {
        // Arrange
        var mockService = new Mock<ICarSpeedService>();
        mockService.Setup(s => s.GetCars()).Throws<FileNotFoundException>();

        var controller = new CarSpeedController(mockService.Object);

        // Act
        var result = controller.GetAverageSpeed();

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
