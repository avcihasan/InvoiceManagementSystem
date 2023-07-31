using InvoiceManagementSystem.Web.Areas.Admin.Models;

namespace InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions
{
    public interface IAdminService
    {
        Task<GetUserVM> CreateUserAsync(CreateUserVM userVM);
        Task<GetUserVM> GetUserAsync(string userId);
        Task<GetUserVM> UpdateUserAsync(UpdateUserVM userVM);
        Task<List<GetUserVM>> GetAllUsersAsync();
        Task DeleteUserAsync(string userId);

        Task<GetApartmentVM> CreateApartmentAsync(CreateApartmentVM apartmentVM);
        Task<GetApartmentVM> GetApartmentAsync(int apartmentId);
        Task<GetApartmentVM> UpdateApartmentAsync(UpdateApartmentVM apartmentVM);
        Task<List<GetApartmentVM>> GetAllApartmentsAsync();
        Task DeleteApartmentAsync(int apartmentId);

        Task<List<GetMessageVM>> GetMessagesAsync();

        Task CreateInvoiceAsync(decimal invoicePrice);

        Task<List<GetPaymentVM>> GetPaymentsAsync();
        Task<List<DebtVM>> GetDebtListAsync();
    }
}
