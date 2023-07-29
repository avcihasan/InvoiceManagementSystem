using InvoiceManagementSystem.Application.DTOs.ApartmentDTOs;
using InvoiceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.DTOs.InvoiceDTOs
{
    public class GetInvoiceDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool Payment { get; set; }
        public GetApartmentDto Apartment { get; set; }
    }
}
