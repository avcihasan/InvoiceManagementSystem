using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.DTOs.MessageDTOs
{
    public class GetMessageDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool Read { get; set; }
    }
}
