using InvoiceManagementSystem.Web.Areas.Admin.Models;

namespace InvoiceManagementSystem.Web.Models
{
    public class GetInvoiceVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool Payment { get; set; }
        public GetApartmentVM Apartment { get; set; }
    }
}
