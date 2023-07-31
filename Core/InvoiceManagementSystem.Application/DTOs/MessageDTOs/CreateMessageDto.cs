using InvoiceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.DTOs.MessageDTOs
{
    public class CreateMessageDto
    {
        public string Body { get; set; }
        public string UserName{ get; set; }
    }
}
