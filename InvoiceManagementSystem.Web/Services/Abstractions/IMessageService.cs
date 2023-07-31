using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Models;

namespace InvoiceManagementSystem.Web.Services.Abstractions
{
    public interface IMessageService
    {
        Task SendMessageAsync(CreateMessageVM createMessage);
        Task<List<GetMessageVM>> GetMessagesAsync();
    }
}
