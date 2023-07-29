﻿using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
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
        Task<List<GetInvoiceDto>> GetInvoicesAsync(string userId);
        Task PaymentAsync(CreditCardDto creditCard, int invoiceId);
        Task SendMessageAsync(CreateMessageDto messageDto);
        Task<List<GetApartmentDto>> GetApartmentAsync(string userId);
        Task<GetUserDto> GetUserAsync(string userId);
    }
}