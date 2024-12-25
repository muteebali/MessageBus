namespace MassTransient.InMemory.Consumer.Dto
{
    public record CurrentTimeDto
    {
        public string Value { get; init; } = string.Empty;
    }
}