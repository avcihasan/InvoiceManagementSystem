using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal Price { get; set; }
        public bool Payment { get; set; }
        public Apartment Apartment { get; set; }

    }
}
