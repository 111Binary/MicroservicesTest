using MicroservicesTest.Common.Events;
using MicroservicesTest.Common.Services;

namespace MicroservicesTest.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ActivityCreated>()
                .SubscribeToEvent<PingReceived>()
                .Build()
                .Run();
        }
    }
}
