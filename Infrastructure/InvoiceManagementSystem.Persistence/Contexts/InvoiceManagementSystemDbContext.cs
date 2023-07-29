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
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
