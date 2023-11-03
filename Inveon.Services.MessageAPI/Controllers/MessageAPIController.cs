using Microsoft.AspNetCore.Mvc;
using Inveon.Services.MessageAPI.Dto;
using Microsoft.AspNetCore.SignalR;
using Inveon.Services.MessageAPI.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace Inveon.Services.MessageAPI.Controllers
{
    [Route("api/messages")]
    public class MessageAPIController : ControllerBase
    {
       
        protected ResponseDto _response;
        private readonly IHubContext<MessageHub> _messageHub;

        public MessageAPIController()
        {
            this._response = new ResponseDto();
        }
        private readonly ILogger<MessageAPIController> _logger;

        public MessageAPIController(ILogger<MessageAPIController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] MessageDto messageDto)
        {
            //same bussines rules
            Console.WriteLine("Here");
            _messageHub.Clients.All.SendAsync("lastMessage",messageDto);
            _response.Result = messageDto;
            return _response;
        }
    }
}