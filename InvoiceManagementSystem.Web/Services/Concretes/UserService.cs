using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Web.Services.Concretes
{
    public class UserService : IUserService
    {
        readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetInvoiceVM> GetInvoiceAsync(int invoiceId)
            =>await _httpClient.GetFromJsonAsync<GetInvoiceVM>($"User/GetInvoice/{invoiceId}");

        public async Task<List<GetInvoiceVM>> GetInvoicesAsync(string username)
            => await _httpClient.GetFromJsonAsync<List<GetInvoiceVM>>($"User/GetInvoices/{username}");

        public async Task PaymentAsync(CreditCardVM creditCard, int invoiceId)
            => await _httpClient.PostAsJsonAsync<CreditCardVM>($"User/Payment?invoiceId={invoiceId}",creditCard);

        public async Task SendMessageAsync(CreateMessageVM createMessage)
            => await _httpClient.PostAsJsonAsync<CreateMessageVM>($"User/SendMessage", createMessage);
    }
}
