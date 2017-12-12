using System;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Command.Models;
using MicroservicesTest.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace MicroservicesTest.ApiGateway.Command.Controllers
{
    /// <summary>
    /// Following the CQRS pattern this Controller for Commands only
    /// </summary>
    [Route("[controller]")]
    public class PingController : Controller
    {
        private readonly IBusClient _busClient;
        

        public PingController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]PingModel model)
        {
            PingCommand command = new PingCommand();
            command.VehicleId = model.VehicleId;
            command.ReceivedAt = DateTime.UtcNow;
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}