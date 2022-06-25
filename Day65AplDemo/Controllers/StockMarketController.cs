using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day65AplDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketController : ControllerBase
    {
        [HttpGet]

        public List<StockMarketInfo> Get()
        {
            var stockInfos = new List<StockMarketInfo>
            {
                new() {Name = "SENSEX", Value = 52349},
                new() {Name = "NIFTY50", Value = 15578},
                new() { Name = "RIL", Value = 5000 }
            };

            return stockInfos;
        }
        [HttpPost]
        public IActionResult Post(StockMarketInfo stockMarketInfo)
        {
            // Save to database
            if (stockMarketInfo.Value < 5)
            {
                //var response = "{\"state\": \"failed\", \"message\": \"This is too less amount\"}";
                var response = new StockMarketApiResponse { State = "Failed", Message = "This is too less amount" };

                return BadRequest(response);
            
            }
            var response2 = new StockMarketApiResponse { State = "Success", Message = "Data saved to database" };
            return Ok(response2);
        }
        [HttpDelete]
        public IActionResult Delete([FromForm] string name)
        {
            return Ok(new StockMarketApiResponse { State = "Success", Message = $"{name} Successfully Deleted" });
        }
    }
    public class StockMarketInfo
    {
        public string Name { get; set; } = null!;
        public double Value { get; set; }
    }
    public class StockMarketApiResponse
    {
        public string State { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
