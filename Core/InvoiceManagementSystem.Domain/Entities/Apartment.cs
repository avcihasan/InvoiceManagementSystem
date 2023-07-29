using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class Apartment:BaseEntity
    {
        public int ApartmentNumber { get; set; }
        public int BlockNumber { get; set; }
        public bool Situation { get; set; }
        public string Type { get; set; }
        public int FloorLocation { get; set; }
        public bool Tenant { get; set; }
        
    }
}
