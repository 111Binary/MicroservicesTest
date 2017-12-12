using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroservicesTest.Common.Mongo;
using MicroservicesTest.Ping.Domain.Models;
using MicroservicesTest.Ping.Domain.Repositories;
using MongoDB.Driver;

namespace MicroservicesTest.Ping.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;

        public CustomMongoSeeder(IMongoDatabase database, 
            ICategoryRepository categoryRepository) 
            : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work",
                "sport",
                "hobby"
            };
            await Task.WhenAll(categories.Select(x => _categoryRepository
                        .AddAsync(new Category(x))));
        }
    }
}