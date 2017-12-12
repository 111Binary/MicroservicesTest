using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public interface IDashboardRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task<IEnumerable<Customer>> BrowseAsync();
    }
}