using InvoiceManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvoiceManagementSystem.Application.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table { get; }
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T,bool>> func);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> func);
        Task<bool> CreateAsync(T entity);
        bool Update(T entity);
        Task<bool> Deleteasync(int id);
        bool Delete(T entity);

    }
}
