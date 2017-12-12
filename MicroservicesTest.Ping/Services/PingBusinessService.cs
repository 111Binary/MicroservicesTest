using System;
using System.Threading.Tasks;
using MicroservicesTest.Common.Exceptions;
using MicroservicesTest.Ping.Domain.Models;
using MicroservicesTest.Ping.Domain.Repositories;

namespace MicroservicesTest.Ping.Services
{
    public class PingBusinessService : IPingBusinessService
    {
        private readonly IPingRepository _pingRepository;

        public PingBusinessService(IPingRepository pingRepository)
        {
            _pingRepository = pingRepository;
        }

        public async Task AddAsync(Guid id, string vehicleId, DateTime recivedAt)
        {

            //var activityCategory = await _pingRepository.GetAsync(category);
            //if (activityCategory == null)
            //{
            //    throw new ActioException("category_not_found", 
            //        $"Category: '{category}' was not found.");
            //}
            var pingInfo = new PingData(id, vehicleId,recivedAt);
            await _pingRepository.AddAsync(pingInfo);
        }
    }
}