using MassTransient.InMemory.Consumer.Dto;
using MassTransit;

namespace MassTransient.InMemory
{
    public class MessagePublisher(IBus bus) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var randomNumber = new Random();

            while (!stoppingToken.IsCancellationRequested)
            {
                //Message 1
                var message = new CurrentTimeDto
                {
                    Value = $"Current time is {DateTime.UtcNow}"
                };
                await bus.Publish(message, stoppingToken);

                //Message 2
                var message2 = new RandomNumberDto
                {
                    Value = $"Random Number is {randomNumber.Next()}"
                };
                await bus.Publish(message2, stoppingToken);

                await Task.Delay(1000, stoppingToken); // Delay to simulate periodic publishing
            }


        }
    }
}
