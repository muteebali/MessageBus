using MassTransient.InMemory.Consumer.Dto;
using MassTransit;

namespace MassTransient.InMemory.Consumer
{
    public class CurrentTimeConsumer(ILogger<CurrentTimeConsumer> logger) : IConsumer<CurrentTimeDto>
    {
        public Task Consume(ConsumeContext<CurrentTimeDto> context)
        {
            logger.LogInformation($"Received message: {context.Message.Value}");
            return Task.CompletedTask;
        }
    }
}
