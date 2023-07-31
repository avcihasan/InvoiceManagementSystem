using InvoiceManagementSystem.Web.Models;

namespace InvoiceManagementSystem.Web.Services.Abstractions
{
    public interface IInvoiceService
    {
        Task<List<GetInvoiceVM>> GetInvoicesAsync(string username);
        Task<GetInvoiceVM> GetInvoiceAsync(int invoiceId);
        Task CreateInvoiceAsync(decimal invoicePrice);
    }
}
