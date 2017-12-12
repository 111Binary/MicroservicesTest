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
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly ILogger _logger;
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;

        public CreateActivityHandler(IBusClient busClient,
            IActivityService activityService, 
            ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: '{command.Id}' for user: '{command.UserId}'.");
            try 
            {
                await _activityService.AddAsync(command.Id, command.UserId,
                    command.Category, command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id,
                    command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));
                _logger.LogInformation($"Activity: '{command.Id}' was created for user: '{command.UserId}'.");

                return;
            }
            catch (MicroservicesTestException ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id,
                    ex.Message, ex.Code));                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id,
                    ex.Message, "error"));                
            }
        }
    }
}