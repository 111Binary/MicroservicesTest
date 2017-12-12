using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetAsync(string vehicleId);
        Task<IEnumerable<Vehicle>> BrowseAsync();
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
    }
}