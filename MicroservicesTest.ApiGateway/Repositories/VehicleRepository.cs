using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoDatabase _database;

        public VehicleRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Vehicle> GetAsync(string vehicleId)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.VehicleId.ToLowerInvariant() == vehicleId.ToLowerInvariant());

        public async Task<IEnumerable<Vehicle>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task AddAsync(Vehicle vehicle)
            => await Collection.InsertOneAsync(vehicle);

        public async Task UpdateAsync(Vehicle vehicle)
        {
            var filter = Builders<Vehicle>.Filter.Eq(x => x.VehicleId, vehicle.VehicleId);
            var update = Builders<Vehicle>.Update.Set(x => x.LatestPingAt, vehicle.LatestPingAt)
                                .Set(x => x.LatestStatus, vehicle.LatestStatus);
            await Collection.UpdateOneAsync(filter, update);

        }

        private IMongoCollection<Vehicle> Collection 
            => _database.GetCollection<Vehicle>("Vehicles");
    }
}