using InvoiceManagementSystem.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.DTOs.PaymentDTOs
{
    public class GetPaymentDto
    {
        public GetUserDto User { get; set; }
        public decimal TotalPayment { get; set; }
    }
}
