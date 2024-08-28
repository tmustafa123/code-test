using CarSpeedAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarSpeedAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarSpeedController : ControllerBase
    {
        private readonly ICarSpeedService _carSpeedService;

        public CarSpeedController(ICarSpeedService carSpeedService)
        {
            _carSpeedService = carSpeedService;
        }

        [HttpGet("average-speed")]
        public IActionResult GetAverageSpeed()
        {
            try
            {
                var cars = _carSpeedService.GetCars();

                if (cars.Count == 0)
                {
                    return BadRequest("No car data found.");
                }

                var averageSpeeds = cars.Select(car => new
                {
                    car.Name,
                    AverageSpeed = _carSpeedService.GetAverageSpeed(car)
                });

                return Ok(averageSpeeds);
            }
            catch (FileNotFoundException)
            {
                return BadRequest("Data file not found.");
            }
        }
    }
}
