using InvoiceManagementSystem.Web.Models;

namespace InvoiceManagementSystem.Web.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<GetInvoiceVM>> GetInvoicesAsync(string username);
        Task<GetInvoiceVM> GetInvoiceAsync(int invoiceId);
        Task PaymentAsync(CreditCardVM creditCard, int invoiceId);
        Task SendMessageAsync(CreateMessageVM createMessage);
    }
}
