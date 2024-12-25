
using MassTransient.InMemory.Consumer.Dto;
using MassTransit;

namespace MassTransient.InMemory
{
    public class MessagePublisher(IBus bus) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = new CurrentTimeDto
                {
                    Value = $"Current time is {DateTime.UtcNow}"
                };
                await bus.Publish(message, stoppingToken);
                await Task.Delay(1000, stoppingToken); // Delay to simulate periodic publishing
            }
        }
    }
}
