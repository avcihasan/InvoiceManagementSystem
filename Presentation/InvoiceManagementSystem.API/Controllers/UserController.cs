using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetInvoices([FromRoute] string userId)
            => Ok(await _userService.GetInvoicesAsync(userId));

        [HttpPost("[action]")]
        public async Task<IActionResult> Payment([FromBody] CreditCardDto creditCard, [FromQuery] int invoiceId)
        {
            await _userService.PaymentAsync(creditCard, invoiceId);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage([FromBody] CreateMessageDto messageDto)
        {
            await _userService.SendMessageAsync(messageDto);
            return Ok();
        }


        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetApartment([FromRoute] string userId)
           => Ok(await _userService.GetApartmentAsync(userId));


        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] string userId)
           => Ok(await _userService.GetUserAsync(userId));

    }
}
