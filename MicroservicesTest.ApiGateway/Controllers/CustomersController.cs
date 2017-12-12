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
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {       
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var customers = await _repository
                .BrowseAsync();

            return Json(customers.Select(x => new {x.Id, x.Name, x.Address}));
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            var customer = await _repository.GetAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Json(customer);
        }
    }
}