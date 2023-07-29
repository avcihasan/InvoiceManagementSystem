using InvoiceManagementSystem.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
        }
    }
}
