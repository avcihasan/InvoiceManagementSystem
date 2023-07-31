using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;

namespace InvoiceManagementSystem.Web.Services.Concretes
{
    public class InvoiceService:IInvoiceService
    {
        readonly HttpClient _httpClient;
        public InvoiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetInvoiceVM> GetInvoiceAsync(int invoiceId)
            => await _httpClient.GetFromJsonAsync<GetInvoiceVM>($"Invoices/{invoiceId}");

        public async Task<List<GetInvoiceVM>> GetInvoicesAsync(string username)
            => await _httpClient.GetFromJsonAsync<List<GetInvoiceVM>>($"Invoices/GetInvoices/{username}");

        public async Task CreateInvoiceAsync(decimal invoicePrice)
            => await _httpClient.GetAsync($"Invoices/CreateInvoice?invoicePrice={invoicePrice}");

    }
}
