using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Application.DTOs.InvoiceDTOs;
using InvoiceManagementSystem.Application.DTOs.MessageDTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class UserService : IUserService
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;
        readonly HttpClient _httpClient;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpClient = httpClient;
        }

        public async Task<List<GetApartmentDto>> GetApartmentAsync(string userId)
             => _mapper.Map<List<GetApartmentDto>>(await _unitOfWork.ApartmentRepository
                 .Table
                 .Include(x => x.Invoices)
                 .Include(x => x.User)
                 .Where(x => x.User.Id == userId)
                 .ToListAsync());

        public async Task<List<GetInvoiceDto>> GetInvoicesAsync(string userId)
        {
            var xxxxxx = _mapper.Map<List<GetInvoiceDto>>(await _unitOfWork.InvoiceRepository
                .Table
                .Include(x => x.Apartment)
                .ThenInclude(x => x.User)
                .Where(x => x.Apartment.User.Id == userId && !x.Payment)
                .ToListAsync());
            return xxxxxx;
        }

        public async Task<GetUserDto> GetUserAsync(string userId)
            => _mapper.Map<GetUserDto>(await _userManager.FindByIdAsync(userId));

        public async Task PaymentAsync(CreditCardDto creditCard, int invoiceId)
        {
            Invoice invoice = await _unitOfWork.InvoiceRepository
                .Table
                .Include(x => x.Apartment)
                .ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == invoiceId);

            PaymentDto paymetDto = new() {CreditCard=creditCard,Price= invoice.Price };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PaymentDto>("payments", paymetDto);
            if (!response.IsSuccessStatusCode)
                throw new Exception("hata");
            if (!( await response.Content.ReadFromJsonAsync<PaymentResponseDto>()).IsSuccess)
                throw new Exception((await response.Content.ReadFromJsonAsync<PaymentResponseDto>()).Description);
           
            invoice.Payment = true;
            await _unitOfWork.SaveAsync();

        }

        public async Task SendMessageAsync(CreateMessageDto messageDto)
        {
            Message message = _mapper.Map<Message>(messageDto);
            message.User = await _userManager.FindByIdAsync(messageDto.UserId);
            await _unitOfWork.MessageRepository.CreateAsync(message);
            await _unitOfWork.SaveAsync();
        }
    }
}
