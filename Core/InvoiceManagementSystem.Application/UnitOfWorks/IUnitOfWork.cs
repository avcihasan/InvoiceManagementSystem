using InvoiceManagementSystem.Application.Abstractions.Repositories;
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
        void Save();
        Task SaveAsync();
    }
}
