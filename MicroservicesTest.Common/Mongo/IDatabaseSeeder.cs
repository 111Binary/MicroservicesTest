using System.Threading.Tasks;

namespace MicroservicesTest.Common.Mongo
{
    public interface IDatabaseSeeder
    {
         Task SeedAsync();
    }
}