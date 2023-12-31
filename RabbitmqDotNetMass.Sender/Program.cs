using MassTransit;
using RabbitmqDotNetMass.Common.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//rabbitmq 

//builder.Services.AddMassTransit(cfg =>
//{
//    cfg.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host(new Uri("rabbitmq://localhost"), h =>
//        {
//            h.Username("guest");
//            h.Password("guest");
//        });
//    });
//});

builder.Services.AddMassTransit(x =>
{
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    }));

    x.AddRequestClient<BalanceUpdateDTO>();
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
