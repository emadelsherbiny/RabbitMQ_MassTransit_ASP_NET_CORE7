using MassTransit;
using Newtonsoft.Json;
using RabbitmqDotNetMass.Common.DTO;
using static MassTransit.Logging.OperationName;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace RabbitmqDotNetMass.Reciver
{
    public class BalanceUpdated : IConsumer<BalanceUpdateDTO>
    {

        public async Task Consume(ConsumeContext<BalanceUpdateDTO> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");

            BalanceUpdateResponseDTO res = new BalanceUpdateResponseDTO()
            {
                Balance = 1000
            };
            await context.RespondAsync(res);


        }
    }
}