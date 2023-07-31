using AutoMapper;
using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.InvoiceDTOs;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.Services
{
    public class InvoiceService:IInvoiceService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateInvoiceAsync(decimal invoicePrice)
        {
            (await _unitOfWork.ApartmentRepository.GetAll().ToListAsync()).ForEach(x => x.Invoices.Add(new() { Price = invoicePrice }));
            await _unitOfWork.SaveAsync();
        }

        public async Task CreateInvoiceAsync(int apartmentId, decimal invoicePrice)
        {
            Apartment apartment = await _unitOfWork.ApartmentRepository.GetAsync(apartmentId);
            apartment.Invoices.Add(new() { Price = invoicePrice });

            await _unitOfWork.SaveAsync();
        }
        public async Task<GetInvoiceDto> GetInvoiceByIdAsync(int invoiceId)
           => _mapper.Map<GetInvoiceDto>(await _unitOfWork.InvoiceRepository.GetAsync(invoiceId));

        public async Task<List<GetInvoiceDto>> GetInvoicesAsync(string userName)
            => _mapper.Map<List<GetInvoiceDto>>(await _unitOfWork.InvoiceRepository
                .Table
                .Include(x => x.Apartment)
                .ThenInclude(x => x.User)
                .Where(x => x.Apartment.User.Name == userName && !x.Payment)
                .ToListAsync());
    }
}
