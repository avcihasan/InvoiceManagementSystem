using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.DTOs
{
    public class PaymentResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Description { get; set; }
    }
}
