using InvoiceManagementSystem.Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.UnitOfWorks
{
    public interface  IUnitOfWork
    {
        public IApartmentRepository ApartmentRepository { get;}
        public IMessageRepository MessageRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
