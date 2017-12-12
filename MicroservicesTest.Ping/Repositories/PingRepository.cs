using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.Ping.Domain.Models;
using MicroservicesTest.Ping.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroservicesTest.Ping.Repositories
{
    public class PingRepository : IPingRepository
    {
        private readonly IMongoDatabase _database;

        public PingRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<PingData> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(PingData pingData)
            => await Collection.InsertOneAsync(pingData);

        public async Task DeleteAsync(Guid id)
            => await Collection.DeleteOneAsync(x => x.Id == id);

        private IMongoCollection<PingData> Collection 
            => _database.GetCollection<PingData>("PingData");
    }
}