using System;
using System.Threading.Tasks;
using MicroservicesTest.Common.Commands;
using MicroservicesTest.Common.Events;
using MicroservicesTest.Common.Exceptions;
using MicroservicesTest.Ping.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace MicroservicesTest.Ping.Handlers
{
    public class PingCommandHandler : ICommandHandler<PingCommand>
    {
        private readonly ILogger _logger;
        private readonly IBusClient _busClient;
        private readonly IPingBusinessService _pingService;

        public PingCommandHandler(IBusClient busClient,
            IPingBusinessService pingService, 
            ILogger<PingCommandHandler> logger)
        {
            _busClient = busClient;
            _pingService = pingService;
            _logger = logger;
        }

        public async Task HandleAsync(PingCommand command)
        {
            _logger.LogInformation($"Received ping data from : '{command.VehicleId}' at: '{command.ReceivedAt.ToString()}'.");
            try 
            {
                await _pingService.AddAsync(Guid.NewGuid(),command.VehicleId,command.ReceivedAt);

                await _busClient.PublishAsync(new PingReceived(command.VehicleId,command.ReceivedAt));

                _logger.LogInformation($"ping data received successfully from: '{command.VehicleId}' at : '{command.ReceivedAt.ToString()}'.");

                return;
            }
            catch (MicroservicesTestException ex)
            {
                _logger.LogError(ex, ex.Message);

                await _busClient.PublishAsync(new PigRejected(command.VehicleId,command.ReceivedAt,ex.Message, ex.Code));                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new PigRejected(command.VehicleId, command.ReceivedAt, ex.Message, "error"));
            }
        }
    }
}