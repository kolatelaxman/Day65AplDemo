using Day65AplDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day65AplDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsroGpsController : ControllerBase
    {
        // GET: api/<IsroGpsController>
        [HttpGet]
        public IActionResult Get()
        { 
            var random = new Random();
            var gpsRusult = new GpsResult { Latitude = random.Next(-90, 90), Longitude = random.Next(-180, 180) };
            return Ok(gpsRusult);
        }




        [HttpPost]
        public IActionResult Post(GpsResult gpsResult)
        {
            GpsBoundaryResult result;

            if (gpsResult.Latitude > 0 && gpsResult.Longitude < 0)
                result = new GpsBoundaryResult { IsInsideCountryBorders = true, Level = DangerLevel.Safe };
            else
                result = new GpsBoundaryResult
                {
                    IsInsideCountryBorders = false,
                    Level = Faker.Enum.Random<DangerLevel>()
                };

            return Ok(result);

        }
    }
}
