using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Models;

namespace InvoiceManagementSystem.Web.Services.Abstractions
{
    public interface IUserService
    {
        Task<GetUserVM> CreateUserAsync(CreateUserVM userVM);
        Task<GetUserVM> GetUserAsync(string userId);
        Task<GetUserVM> UpdateUserAsync(UpdateUserVM userVM);
        Task<List<GetUserVM>> GetAllUsersAsync();
        Task DeleteUserAsync(string userName);
        Task<List<DebtVM>> GetDebtListAsync();
    }
}
