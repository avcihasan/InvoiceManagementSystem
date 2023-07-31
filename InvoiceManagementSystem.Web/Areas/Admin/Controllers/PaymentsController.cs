using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentsController : Controller
    {
        readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> GetPayments()
              => View(await _paymentService.GetPaymentsAsync());

    }
}
