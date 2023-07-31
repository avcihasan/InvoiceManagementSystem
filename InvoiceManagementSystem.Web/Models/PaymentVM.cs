namespace InvoiceManagementSystem.Web.Models
{
    public class PaymentVM
    {
        public CreditCardVM CreditCard { get; set; }
        public decimal Price { get; set; }
    }
}
