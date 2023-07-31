using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using System.Net.Http;

namespace InvoiceManagementSystem.Web.Services.Concretes
{
    public class PaymentService:IPaymentService
    {
        readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task PaymentAsync(CreditCardVM creditCard, int invoiceId)
            => await _httpClient.PostAsJsonAsync<CreditCardVM>($"Payments?invoiceId={invoiceId}", creditCard);
        public async Task<List<GetPaymentVM>> GetPaymentsAsync()
           => await _httpClient.GetFromJsonAsync<List<GetPaymentVM>>("Payments");
    }
}
