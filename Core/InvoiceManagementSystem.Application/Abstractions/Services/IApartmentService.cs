using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface IApartmentService
    {
        Task<List<GetApartmentDto>> GetApartmentByUserNameAsync(string userName);
        Task<GetApartmentDto> GetApartmentByIdAsync(int apartmentId);
        Task<List<GetApartmentDto>> GetAllApartentsAsync();
        Task<GetApartmentDto> CreateApartmentAsync(CreateApartmentDto apartmentDto);
        Task<GetApartmentDto> UpdateApartmentAsync(UpdateApartmentDto apartmentDto);
        Task DeleteApartmentAsync(int apartmentId);
    }
}
