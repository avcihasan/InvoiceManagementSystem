using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class AppUser:IdentityUser<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string CarPlateNumber { get; set; }

        public List<Invoice> Invoices { get; set; }
        public List<Dues> Dueses { get; set; }
    }
}
