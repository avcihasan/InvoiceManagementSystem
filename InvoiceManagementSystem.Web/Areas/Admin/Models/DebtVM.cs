namespace InvoiceManagementSystem.Web.Areas.Admin.Models
{
    public class DebtVM
    {
        public GetUserVM User { get; set; }
        public decimal TotalDebt { get; set; }
    }
}
