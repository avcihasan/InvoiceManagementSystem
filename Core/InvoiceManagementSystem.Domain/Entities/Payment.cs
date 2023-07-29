using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class Payment:BaseEntity
    {
        public Invoice Invoice { get; set; }
        public AppUser User { get; set; }
    }
}
