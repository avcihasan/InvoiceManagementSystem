using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Models;

namespace InvoiceManagementSystem.Web.Services.Abstractions
{
    public interface IPaymentService
    {
        Task PaymentAsync(CreditCardVM creditCard, int invoiceId);
        Task<List<GetPaymentVM>> GetPaymentsAsync();

    }
}
