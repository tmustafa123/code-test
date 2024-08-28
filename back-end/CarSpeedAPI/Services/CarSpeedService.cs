using CarSpeedAPI.Entities;
using Newtonsoft.Json;

namespace CarSpeedAPI.Services
{
    public class CarSpeedService : ICarSpeedService
    {
        private readonly string _filePath;

        public CarSpeedService(string filePath)
        {
            _filePath = filePath;
        }

        public List<Car> GetCars()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("Data file not found.");
            }

            var jsonData = File.ReadAllText(_filePath);
            var cars = JsonConvert.DeserializeObject<List<Car>>(jsonData);
            return cars ?? new List<Car>();
        }

        public double GetAverageSpeed(Car car)
        {
            return car.Speeds.Average();
        }
    }
}