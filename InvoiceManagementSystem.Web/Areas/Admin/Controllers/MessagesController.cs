using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessagesController : Controller
    {
        readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> GetMessages()
             => View(await _messageService.GetMessagesAsync());
    }
}
