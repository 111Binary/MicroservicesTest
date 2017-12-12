using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;

namespace MicroservicesTest.ApiGateway.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task<IEnumerable<Activity>> BrowseAsync(Guid userId);
        Task AddAsync(Activity activity);
    }
}