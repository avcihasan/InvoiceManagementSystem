using InvoiceManagementSystem.Web.Areas.Admin.Models;

namespace InvoiceManagementSystem.Web.Services.Abstractions
{
    public interface IApartmentService
    {
        Task<GetApartmentVM> CreateApartmentAsync(CreateApartmentVM apartmentVM);
        Task<GetApartmentVM> GetApartmentAsync(int apartmentId);
        Task<GetApartmentVM> UpdateApartmentAsync(UpdateApartmentVM apartmentVM);
        Task<List<GetApartmentVM>> GetAllApartmentsAsync();
        Task DeleteApartmentAsync(int apartmentId);
    }
}
