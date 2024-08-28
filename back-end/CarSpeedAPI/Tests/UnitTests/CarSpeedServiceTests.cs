using System.IO;
using Xunit;
using CarSpeedAPI.Services;
using CarSpeedAPI.Entities;

public class CarSpeedServiceTests
{
    private readonly string _testFilePath;

    public CarSpeedServiceTests()
    {
        // Path to the input.json file 
        _testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "input.json");
    }

    [Fact]
    public void GetCars_ShouldReturnListOfCars_WhenFileExists()
    {
        // Arrange
        var service = new CarSpeedService(_testFilePath);

        // Act
        var cars = service.GetCars();

        // Assert
        Assert.NotNull(cars);
        Assert.NotEmpty(cars);
    }

    [Fact]
    public void GetAverageSpeed_ShouldReturnCorrectAverage_WhenSpeedsAreGiven()
    {
        // Arrange
        var car = new Car
        {
            Name = "Car1",
            Speeds = new List<int> { 60, 70, 80, 90, 100 }
        };

        var expectedAverage = 80;
        var service = new CarSpeedService("dummyPath"); 

        // Act
        var averageSpeed = service.GetAverageSpeed(car);

        // Assert
        Assert.Equal(expectedAverage, averageSpeed);
    }

    [Fact]
    public void GetCars_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
    {
        // Arrange
        var nonExistentFilePath = "nonExistentFile.json";
        var service = new CarSpeedService(nonExistentFilePath);

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => service.GetCars());
    }
}
