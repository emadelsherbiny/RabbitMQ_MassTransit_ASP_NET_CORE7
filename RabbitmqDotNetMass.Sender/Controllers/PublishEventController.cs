using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitmqDotNetMass.Common.DTO;
using System;

namespace RabbitmqDotNetMass.Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishEventController : ControllerBase
    {
        private readonly IBus _bus;
        public PublishEventController(IBus bus)
        {
            _bus = bus;
        }
        //Command
        [HttpPost]
        [Route("Test")]

        public async Task<IActionResult> Test(PersonDTO message)
        {
             
            await _bus.Publish(message);
            return Ok("Done publish event");
        }
    }
}
