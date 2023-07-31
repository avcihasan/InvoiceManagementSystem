using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Controllers
{
    public class PaymentsController : Controller
    {
        readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Payment(int invoiceId, string invoicePrice)
        {
            TempData["InvoicePrice"] = invoicePrice;
            TempData["InvoicePrice1"] = invoicePrice;
            TempData["InvoiceId"] = invoiceId;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Payment(PaymentVM payment)
        {
            payment.Price = decimal.Parse(TempData["InvoicePrice1"].ToString());
            await _paymentService.PaymentAsync(payment.CreditCard, (int)TempData["InvoiceId"]);
            return RedirectToAction(nameof(Index));
        }
    }
}
