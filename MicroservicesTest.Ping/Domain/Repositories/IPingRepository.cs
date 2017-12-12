using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.Ping.Domain.Models;

namespace MicroservicesTest.Ping.Domain.Repositories
{
    public interface IPingRepository
    {
        Task<PingData> GetAsync(Guid id);
        Task AddAsync(PingData pingData);
        Task DeleteAsync(Guid id);
    }
}