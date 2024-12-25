using MassTransient.InMemory;
using MassTransient.InMemory.Consumer;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mass Transient Configuration
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<CurrentTimeConsumer>();
    busConfigurator.UsingInMemory((context, config) =>
    {
        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddHostedService<MessagePublisher>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
