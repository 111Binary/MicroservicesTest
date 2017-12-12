using System;
using System.Linq;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Repositories;
using MicroservicesTest.Common.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTest.ApiGateway.Controllers
{
    /// <summary>
    /// Following the CQRS pattern this Controller for Queries only
    /// </summary>
    [Route("[controller]")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {       
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var customers = await _repository
                .BrowseAsync();

            return Json(customers.Select(x => new {
                x.CustomerId,
                x.VehicleId,
                x.RegNo,
                x.LatestPingAt,
                Status =(x.LatestPingAt.HasValue?x.LatestPingAt.Value.ToUniversalTime().AddMinutes(1)>DateTime.UtcNow:false)
            }));
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(string vehicleId)
        {
            var customer = await _repository.GetAsync(vehicleId);
            if (customer == null)
            {
                return NotFound();
            }
            return Json(customer);
        }
    }
}