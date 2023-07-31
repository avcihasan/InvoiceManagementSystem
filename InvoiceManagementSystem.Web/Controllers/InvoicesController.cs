using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Controllers
{
    public class InvoicesController : Controller
    {
        readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<IActionResult> GetInvoices()
            => View(await _invoiceService.GetInvoicesAsync("hasan"));
        public async Task<IActionResult> GetInvoice(int invoiceId)
           => View(await _invoiceService.GetInvoiceAsync(invoiceId));
    }
}
