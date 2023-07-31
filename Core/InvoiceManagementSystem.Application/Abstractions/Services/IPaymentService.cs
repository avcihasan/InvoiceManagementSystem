using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        Task PaymentAsync(CreditCardDto creditCard, int invoiceId);
        Task<List<GetPaymentDto>> GetAllPaymentsAsync();
    }
}
