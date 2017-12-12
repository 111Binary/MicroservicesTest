using MicroservicesTest.Common.Services;

namespace MicroservicesTest.ApiGateway.Command
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
               .UseRabbitMq()
               .Build()
               .Run();
        }

        
    }
}
