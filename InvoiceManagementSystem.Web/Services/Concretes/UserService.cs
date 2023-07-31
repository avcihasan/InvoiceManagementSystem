using InvoiceManagementSystem.Web.Areas.Admin.Models;
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

        public async Task<GetUserVM> CreateUserAsync(CreateUserVM userVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<CreateUserVM>("Users", userVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetUserVM>();
        }
        public async Task DeleteUserAsync(string userName)
            => await _httpClient.DeleteAsync($"Users/{userName}");
        public async Task<List<GetUserVM>> GetAllUsersAsync()
            => await _httpClient.GetFromJsonAsync<List<GetUserVM>>("Users");
        public async Task<GetUserVM> GetUserAsync(string userId)
            => await _httpClient.GetFromJsonAsync<GetUserVM>($"Users/{userId}");
        public async Task<GetUserVM> UpdateUserAsync(UpdateUserVM userVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsJsonAsync<UpdateUserVM>("Users", userVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetUserVM>();
        }
        public async Task<List<DebtVM>> GetDebtListAsync()
            => await _httpClient.GetFromJsonAsync<List<DebtVM>>("Users/GetDebtList");

    }
}
