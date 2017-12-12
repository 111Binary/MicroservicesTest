using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task<IEnumerable<Customer>> BrowseAsync();
        Task AddAsync(Customer customer);
    }
}