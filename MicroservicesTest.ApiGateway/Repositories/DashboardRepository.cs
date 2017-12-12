using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IMongoDatabase _database;

        public DashboardRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Customer> GetAsync(Guid id)
            => await CustomersCollection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Customer>> BrowseAsync()
            => await CustomersCollection
                .AsQueryable()
                .ToListAsync();

        

        private IMongoCollection<Customer> CustomersCollection 
            => _database.GetCollection<Customer>("Customers");
    }
}