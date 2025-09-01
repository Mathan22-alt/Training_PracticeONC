using Microsoft.AspNetCore.Mvc;


namespace ASPwidDI_1._1.Controllers
{
    using ASPwidDI_1._1.Service;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        // DI via constructor
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(_messageService.GetMessage());
        }

        [HttpPost]
        public IActionResult SaveMessage([FromBody] string msg)
        {
            _messageService.SaveMessage(msg);
            return Ok("Message saved!");
        }
    }

}
