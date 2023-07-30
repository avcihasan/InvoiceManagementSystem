using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface IAdminService
    {
        Task<List<GetApartmentDto>> GetAllApartentsAsync();
        Task<GetApartmentDto> CreateApartmentAsync(CreateApartmentDto apartmentDto);
        Task<GetApartmentDto> UpdateApartmentAsync(UpdateApartmentDto apartmentDto);
        Task DeleteApartmentAsync(int apartmentId);
        Task<GetUserDto> GetUserByIdAsync(string userId);
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
        Task<GetUserDto> UpdateUserAsync( UpdateUserDto userDto);
        Task DeleteUserAsync(string userId);
        Task CreateInvoiceAsync(decimal invoicePrice);
        Task CreateInvoiceAsync(int apartmentId, decimal invoicePrice);
        Task<List<GetPaymentDto>> GetAllPaymentsAsync();
        Task<List<GetMessageDto>> GetAllMessagesAsync();
        Task<List<GetMessageDto>> GetAllMessagesAsync(bool read);
        Task<List<DebtDto>> GetDebtListAsync();
    }
}
