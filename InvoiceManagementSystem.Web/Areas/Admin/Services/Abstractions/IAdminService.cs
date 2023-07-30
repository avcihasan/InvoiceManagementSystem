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
    }
}
