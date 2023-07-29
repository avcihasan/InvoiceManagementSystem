﻿using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.UnitOfWorks;
using InvoiceManagementSystem.Persistence.Contexts;
using InvoiceManagementSystem.Persistence.Services;
using InvoiceManagementSystem.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagementSystem.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection service,IConfiguration configuration)
        {

            service.AddDbContext<InvoiceManagementSystemDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("SqlServer"))
            );
           
            service.AddScoped<IAdminService, AdminService>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
