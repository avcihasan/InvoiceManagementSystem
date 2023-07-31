using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Controllers
{
    public class MessagesController : Controller
    {
        readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult SendMessage()
           => View();
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageVM createMessageVM)
        {
            createMessageVM.UserName = "hasan";
            await _messageService.SendMessageAsync(createMessageVM);
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
    }
}
