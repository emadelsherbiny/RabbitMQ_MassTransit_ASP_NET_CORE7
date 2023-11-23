using MassTransit;
using MassTransit.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitmqDotNetMass.Common.DTO;

namespace RabbitmqDotNetMass.Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestResponseController : ControllerBase
    { 
    private readonly IRequestClient<BalanceUpdateDTO> _client;
    public RequestResponseController(IRequestClient<BalanceUpdateDTO> client)
    {
        _client = client;
    }
    //Command
    [HttpPost]
    [Route("Test")]

    public async Task<IActionResult> Test(BalanceUpdateDTO message)
    {
         var request =   _client.Create(message);
            var response =await request.GetResponse<BalanceUpdateResponseDTO>();
        return Ok(response);
    }
}
}

