using MassTransient.InMemory.Consumer.Dto;
using MassTransit;

namespace MassTransient.InMemory.Consumer
{
    public class RandomNumberConsumer(ILogger<RandomNumberConsumer> logger) : IConsumer<RandomNumberDto>
    {
        public Task Consume(ConsumeContext<RandomNumberDto> context)
        {
            logger.LogInformation($"Random number: {context.Message.Value}");
            return Task.CompletedTask;
        }
    }
}
