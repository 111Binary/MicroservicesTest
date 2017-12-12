using MicroservicesTest.Common.Commands;
using MicroservicesTest.Common.Services;

namespace MicroservicesTest.Ping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<PingCommand>()
                .Build()
                .Run();
        }
    }
}
