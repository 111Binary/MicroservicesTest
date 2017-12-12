using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTest.Ping.Domain.Models;

namespace MicroservicesTest.Ping.Domain.Repositories
{
    public interface ICategoryRepository
    {
         Task<Category> GetAsync(string name);
         Task<IEnumerable<Category>> BrowseAsync();
         Task AddAsync(Category category);
    }
}