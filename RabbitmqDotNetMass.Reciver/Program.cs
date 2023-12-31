using MassTransit;
using RabbitmqDotNetMass.Reciver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("sendMsg", e =>
        {
            e.Consumer<OrderCreatedConsumer>(context);

        });
        cfg.ReceiveEndpoint("PublishEvent", e =>
        {
            e.Consumer<PersonCreatedConsumer>(context);

        });
        cfg.ReceiveEndpoint("RequestReponseMsg", e =>
        {
            e.Consumer<BalanceUpdated>(context);

        });

    });
    x.AddConsumer<OrderCreatedConsumer>();
    x.AddConsumer<PersonCreatedConsumer>();
    x.AddConsumer<BalanceUpdated>();

});
builder.Services.AddMassTransitHostedService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
