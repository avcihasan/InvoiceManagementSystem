using InvoiceManagementSystem.Domain.Entities;
using System.Linq.Expressions;

namespace InvoiceManagementSystem.Application.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
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
