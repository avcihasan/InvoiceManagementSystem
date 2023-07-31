using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
            => Ok(await _messageService.GetAllMessagesAsync());

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] CreateMessageDto messageDto)
        {
            await _messageService.SendMessageAsync(messageDto);
            return Ok();
        }
    }
}
