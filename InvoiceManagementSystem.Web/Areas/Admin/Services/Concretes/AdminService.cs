using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Web.Areas.Admin.Services.Concretes
{
    public class AdminService : IAdminService
    {

        readonly HttpClient _httpClient;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetApartmentVM> CreateApartmentAsync(CreateApartmentVM apartmentVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<CreateApartmentVM>("Admin/CreateApartment", apartmentVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetApartmentVM>();
        }

        public async Task CreateInvoiceAsync(decimal invoicePrice)
            => await _httpClient.GetAsync($"Admin/CreateInvoice?invoicePrice={invoicePrice}");

        public async Task<GetUserVM> CreateUserAsync(CreateUserVM userVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<CreateUserVM>("Admin/CreateUser", userVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetUserVM>();
        }

        public async Task DeleteApartmentAsync(int apartmentId)
             => await _httpClient.DeleteAsync($"Admin/DeleteApartment/{apartmentId}");

        public async Task DeleteUserAsync(string userId)
            => await _httpClient.DeleteAsync($"Admin/DeleteUser/{userId}");

        public async Task<List<GetApartmentVM>> GetAllApartmentsAsync()
            => await _httpClient.GetFromJsonAsync<List<GetApartmentVM>>("Admin/GetApartments");

        public async Task<List<GetUserVM>> GetAllUsersAsync()
            => await _httpClient.GetFromJsonAsync<List<GetUserVM>>("Admin/GetUsers");

        public async Task<GetApartmentVM> GetApartmentAsync(int apartmentId)
            => await _httpClient.GetFromJsonAsync<GetApartmentVM>($"Admin/GetApartment/{apartmentId}");

        public async Task<List<DebtVM>> GetDebtListAsync()
            => await _httpClient.GetFromJsonAsync<List<DebtVM>>("Admin/GetDebtList");

        public async Task<List<GetMessageVM>> GetMessagesAsync()
            => await _httpClient.GetFromJsonAsync<List<GetMessageVM>>("Admin/GetAllMessages");

        public async Task<List<GetPaymentVM>> GetPaymentsAsync()
            => await _httpClient.GetFromJsonAsync<List<GetPaymentVM>>("Admin/GetAllPayments");

        public async Task<GetUserVM> GetUserAsync(string userId)
            => await _httpClient.GetFromJsonAsync<GetUserVM>($"Admin/GetUser/{userId}");

        public async Task<GetApartmentVM> UpdateApartmentAsync(UpdateApartmentVM apartmentVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsJsonAsync<UpdateApartmentVM>("Admin/UpdateApartment", apartmentVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetApartmentVM>();
        }

        public async Task<GetUserVM> UpdateUserAsync(UpdateUserVM userVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsJsonAsync<UpdateUserVM>("Admin/UpdateUser", userVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetUserVM>();
        }
    }
}
