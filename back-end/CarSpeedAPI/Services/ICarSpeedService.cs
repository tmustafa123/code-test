using CarSpeedAPI.Entities;

namespace CarSpeedAPI.Services
{
    public interface ICarSpeedService
    {
        List<Car> GetCars();
        double GetAverageSpeed(Car car);
    }
}