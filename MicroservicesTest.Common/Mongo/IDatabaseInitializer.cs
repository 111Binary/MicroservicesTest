using System.Threading.Tasks;

namespace MicroservicesTest.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}