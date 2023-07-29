using InvoiceManagementSystem.Application.Abstractions.Repositories;
using InvoiceManagementSystem.Domain.Entities;
using InvoiceManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace InvoiceManagementSystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly DbSet<T> _dbSet;
        public GenericRepository(InvoiceManagementSystemDbContext context)
        {
            _dbSet = context.Set<T>();
        }
        public DbSet<T> Table => _dbSet;

        public async Task<bool> CreateAsync(T entity)
        {
            EntityEntry entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> Deleteasync(int id)
            => Delete(await GetAsync(id));

        public bool Delete(T entity)
        {
            EntityEntry entityEntry = _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<T> GetAsync(int id)
           => await _dbSet.FindAsync(id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> func)
           => await _dbSet.Where(func).FirstOrDefaultAsync();

        public IQueryable<T> GetAll()
            => _dbSet.AsQueryable();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> func)
             => _dbSet.Where(func);

        public bool Update(T entity)
        {
            EntityEntry entityEntry = _dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
