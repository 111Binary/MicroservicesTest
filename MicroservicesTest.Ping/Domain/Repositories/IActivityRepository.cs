using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.Ping.Domain.Models;

namespace MicroservicesTest.Ping.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
        Task DeleteAsync(Guid id);
    }
}