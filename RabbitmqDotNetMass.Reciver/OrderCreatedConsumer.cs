using MassTransit;
using Newtonsoft.Json;
using RabbitmqDotNetMass.Common.DTO;

namespace RabbitmqDotNetMass.Reciver
{
    public class OrderCreatedConsumer : IConsumer<OrderDto>
    {
        public async Task Consume(ConsumeContext<OrderDto> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");
        }
    }
}