using InvoiceManagementSystem.Web.Areas.Admin.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoicesController : Controller
    {
        readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IActionResult CreateInvoice()
        {
            ViewBag.date = DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("tr-TR", true));
            ViewBag.month = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("tr-TR", true));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(decimal invoicePrice)
        {
            await _invoiceService.CreateInvoiceAsync(invoicePrice);
            return RedirectToAction(nameof(UsersController.GetUsers),"Users");
        }

    }
}
