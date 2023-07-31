using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Areas.Admin.Services.Abstractions;
using System.Collections.Generic;

namespace InvoiceManagementSystem.Web.Areas.Admin.Services.Concretes
{
    public class AdminService : IAdminService
    {

        readonly HttpClient _httpClient;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
  
    }
}
