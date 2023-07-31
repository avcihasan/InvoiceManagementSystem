using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.InvoiceDTOs;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface  IUserService
    {
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
        Task<GetUserDto> UpdateUserAsync(UpdateUserDto userDto);
        Task DeleteUserAsync(string userId);
        Task<List<DebtDto>> GetDebtListAsync();
        Task<GetUserDto> GetUserByUserNameOrIdAsync(string userNameOrId);
    }
}
