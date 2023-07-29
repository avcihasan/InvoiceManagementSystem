﻿using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface IAdminService
    {
        Task<List<GetApartmentDto>> GetAllApartentsAsync();
        Task<GetApartmentDto> CreateApartmentAsync(CreateApartmentDto apartmentDto);
        Task<GetApartmentDto> UpdateApartmentAsync(UpdateApartmentDto apartmentDto);
        Task DeleteApartmentAsync(int apartmentId);
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
        Task<GetUserDto> UpdateUserAsync( UpdateUserDto userDto);
        Task DeleteUserAsync(string userId);
        //Task CreateInvoiceAndDues(decimal amount);
        //Task CreateInvoiceAndDues(string userId,decimal amount);
        //Task GetPayments();
        //Task GetMessages();
    }
}