using InvoiceManagementSystem.Application.DTOs.InvoiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Abstractions.Services
{
    public interface  IInvoiceService
    {
        Task<List<GetInvoiceDto>> GetInvoicesAsync(string userName);
        Task<GetInvoiceDto> GetInvoiceByIdAsync(int invoiceId);

        Task CreateInvoiceAsync(decimal invoicePrice);
        Task CreateInvoiceAsync(int apartmentId, decimal invoicePrice);
    }
}
