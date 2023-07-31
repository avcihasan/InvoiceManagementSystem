using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class PaymentService:IPaymentService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly HttpClient _httpClient;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<List<GetPaymentDto>> GetAllPaymentsAsync()
        {
            List<Payment> paymnets = await _unitOfWork.PaymentRepository.Table.Include(x => x.Invoice).Include(x => x.User).ToListAsync();
            List<GetPaymentDto> getPaymentDtos = new();
            paymnets.ForEach(x =>
            {
                getPaymentDtos.Add(new() { TotalPayment = x.Invoice.Price, User = _mapper.Map<GetUserDto>(x.User) });
            });
            return getPaymentDtos;
        }

        public async Task PaymentAsync(CreditCardDto creditCard, int invoiceId)
        {
            Invoice invoice = await _unitOfWork.InvoiceRepository
                .Table
                .Include(x => x.Apartment)
                .ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.Id == invoiceId);

            PaymentDto paymetDto = new() { CreditCard = creditCard, Price = invoice.Price };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PaymentDto>("payments", paymetDto);
            if (!response.IsSuccessStatusCode)
                throw new Exception("hata");
            if (!(await response.Content.ReadFromJsonAsync<PaymentResponseDto>()).IsSuccess)
                throw new Exception((await response.Content.ReadFromJsonAsync<PaymentResponseDto>()).Description);

            invoice.Payment = true;
            await _unitOfWork.SaveAsync();

        }
    }
}
