using InvoiceManagementSystem.Application.Abstractions.Repositories;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Persistence.Contexts;
using InvoiceManagementSystem.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InvoiceManagementSystemDbContext _context;

        public UnitOfWork(InvoiceManagementSystemDbContext context)
        {
            _context = context;
            ApartmentRepository = new ApartmentRepository(context);
        }

        public IApartmentRepository ApartmentRepository { get; private set; }

        public void Save()
            => _context.SaveChanges();

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
