using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTest.Ping.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from MicroservicesTest.Ping API!");
    }
}