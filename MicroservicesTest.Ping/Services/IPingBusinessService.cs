using System;
using System.Threading.Tasks;

namespace MicroservicesTest.Ping.Services
{
    public interface IPingBusinessService
    {
        Task AddAsync(Guid id, string vehicleId, DateTime recivedAt);
    }
}