using InvoiceManagementSystem.Application.Abstractions.Repositories;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.Repositories
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(InvoiceManagementSystemDbContext context) : base(context)
        {
        }
    }
}
