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
        public AppUser()
        {
            Messages = new List<Message>();
            Apartments = new List<Apartment>();
            Payments = new List<Payment>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string CarPlateNumber { get; set; }
        public List<Message> Messages { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<Payment> Payments { get; set; }

    }
}
