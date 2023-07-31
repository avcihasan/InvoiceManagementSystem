using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using System.Net.Http;

namespace InvoiceManagementSystem.Web.Services.Concretes
{
    public class MessageService: IMessageService
    {
        readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMessageAsync(CreateMessageVM createMessage)
          => await _httpClient.PostAsJsonAsync<CreateMessageVM>($"Messages", createMessage);

        public async Task<List<GetMessageVM>> GetMessagesAsync()
            => await _httpClient.GetFromJsonAsync<List<GetMessageVM>>("Messages");
    }
}
