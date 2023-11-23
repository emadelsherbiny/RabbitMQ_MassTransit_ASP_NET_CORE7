using MassTransit;
using Newtonsoft.Json;
using RabbitmqDotNetMass.Common.DTO;

namespace RabbitmqDotNetMass.Reciver
{ 
    public class PersonCreatedConsumer : IConsumer<PersonDTO>
    {
        public async Task Consume(ConsumeContext<PersonDTO> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"Person created message: {jsonMessage}");
        }
    }
}