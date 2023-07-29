using InvoiceManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementSystem.Persistence.Contexts
{
    public class InvoiceManagementSystemDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public InvoiceManagementSystemDbContext(DbContextOptions<InvoiceManagementSystemDbContext> options):base(options)
        {
        }

        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}
