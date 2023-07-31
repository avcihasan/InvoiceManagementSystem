using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;

namespace InvoiceManagementSystem.Web.Services.Concretes
{
    public class ApartmentService:IApartmentService
    {

        readonly HttpClient _httpClient;

        public ApartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetApartmentVM> CreateApartmentAsync(CreateApartmentVM apartmentVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<CreateApartmentVM>("Apartments", apartmentVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetApartmentVM>();
        }
        public async Task DeleteApartmentAsync(int apartmentId)
             => await _httpClient.DeleteAsync($"Apartments/{apartmentId}");
        public async Task<List<GetApartmentVM>> GetAllApartmentsAsync()
            => await _httpClient.GetFromJsonAsync<List<GetApartmentVM>>("Apartments");
        public async Task<GetApartmentVM> GetApartmentAsync(int apartmentId)
            => await _httpClient.GetFromJsonAsync<GetApartmentVM>($"Apartments/{apartmentId}");
        public async Task<GetApartmentVM> UpdateApartmentAsync(UpdateApartmentVM apartmentVM)
        {
            HttpResponseMessage responseMessage = await _httpClient.PutAsJsonAsync<UpdateApartmentVM>("Apartments", apartmentVM);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("hata");
            return await responseMessage.Content.ReadFromJsonAsync<GetApartmentVM>();
        }
    }
}
