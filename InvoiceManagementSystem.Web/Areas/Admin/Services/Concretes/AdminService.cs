using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions;

namespace InvoiceManagementSystem.Web.Areas.Admin.Services.Concretes
{
    public class AdminService : IAdminService
    {

        readonly HttpClient _httpClient;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetUserVM> CreateUserAsync(CreateUserVM userVM)
        {
           HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<CreateUserVM>("Admin/CreateUser", userVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
          return  await responseMessage.Content.ReadFromJsonAsync<GetUserVM>();
        }

        public async Task DeleteUserAsync(string userId)
            => await _httpClient.DeleteAsync($"Admin/DeleteUser/{userId}");

        public async Task<List<GetUserVM>> GetAllUsersAsync()
            => await _httpClient.GetFromJsonAsync<List<GetUserVM>>("Admin/GetUsers");

        public async Task<GetUserVM> GetUserAsync(string userId)
            => await _httpClient.GetFromJsonAsync<GetUserVM>($"Admin/GetUser/{userId}");

        public async Task<GetUserVM> UpdateUserAsync(UpdateUserVM userVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsJsonAsync<UpdateUserVM>("Admin/UpdateUser", userVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetUserVM>();
        }
    }
}
