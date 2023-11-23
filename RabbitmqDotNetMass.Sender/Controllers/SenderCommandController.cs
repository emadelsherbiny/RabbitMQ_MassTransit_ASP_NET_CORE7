using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitmqDotNetMass.Common.DTO;

namespace RabbitmqDotNetMass.Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderCommandController : ControllerBase
    {

        private readonly IBus _bus;
        public SenderCommandController(IBus bus)
        {
            _bus = bus;
        }
        //Command
        [HttpPost]
        [Route("Test")]

        public async Task<IActionResult> Test(OrderDto message)
        { 
            var url = new Uri("rabbitmq://localhost/sendMsg");
            var endpoint=await _bus.GetSendEndpoint(url);
            await endpoint.Send(message);
            return Ok("done using command from one sender to one reciver ");
        }
    }
}
