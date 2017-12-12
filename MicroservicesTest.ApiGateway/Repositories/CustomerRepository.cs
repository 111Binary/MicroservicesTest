using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoDatabase _database;

        public CustomerRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Customer> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Customer>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task AddAsync(Customer activity)
            => await Collection.InsertOneAsync(activity);

        private IMongoCollection<Customer> Collection 
            => _database.GetCollection<Customer>("Customers");
    }
}