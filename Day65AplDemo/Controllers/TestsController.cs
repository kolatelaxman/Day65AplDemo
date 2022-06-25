using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day65AplDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get (int num)
        {
            var mathResult = new MathResult { Square = num * num, Cube = num * num * num };
            return Ok (mathResult);
        }
        [HttpPost]
        public IActionResult Post([FromForm]int num)
        {
            var mathResult = new MathResult { Square = num * num, Cube = num * num };
            return Ok (mathResult);
        }
    }
    class MathResult
    {
        public double Square { get; set; }
        public double Cube { get; set; }
    }
}
