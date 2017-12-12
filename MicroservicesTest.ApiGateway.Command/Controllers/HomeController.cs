using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTest.ApiGateway.Command.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from MicroservicesTest.ApiGateway.Command !");
    }
}