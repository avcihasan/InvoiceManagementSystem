using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public AppUser User { get; set; }

    }
}
