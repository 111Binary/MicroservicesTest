using System;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;
using MicroservicesTest.ApiGateway.Repositories;
using MicroservicesTest.Common.Events;

namespace MicroservicesTest.ApiGateway.Handlers
{
    public class PingReceivedHandler : IEventHandler<PingReceived>
    {
        private readonly IVehicleRepository _repository;

        public PingReceivedHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(PingReceived @event)
        {
            Console.WriteLine($"Ping Received from: {@event.VehicleId}");
            var vehicle = await _repository.GetAsync(@event.VehicleId);
            if (vehicle != null)
            {
                vehicle.LatestStatus = true;
                vehicle.LatestPingAt = @event.ReceivedAt;
                await _repository.UpdateAsync(vehicle);
                Console.WriteLine($"Vehicle status updated: {@event.VehicleId}");
            }
            else
            {
                Console.WriteLine($"Vehicle 404: {@event.VehicleId}");
            }
            
        }
    }
}