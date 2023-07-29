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
            MessageRepository = new MessageRepository(context);
            PaymentRepository = new PaymentRepository(context);
            InvoiceRepository = new InvoiceRepository(context);
        }

        public IApartmentRepository ApartmentRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }
        public IInvoiceRepository InvoiceRepository { get; private set; }

        public void Save()
            => _context.SaveChanges();

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
