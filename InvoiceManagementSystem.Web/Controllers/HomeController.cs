using InvoiceManagementSystem.Web.Models;
using InvoiceManagementSystem.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceManagementSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public async Task<IActionResult> GetInvoices()
            => View(await _userService.GetInvoicesAsync("hasan"));
        public async Task<IActionResult> GetInvoice(int invoiceId)
           => View(await _userService.GetInvoiceAsync(invoiceId));
        public IActionResult SendMessage()
            => View();
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageVM createMessageVM)
        {
            createMessageVM.UserName = "hasan";
            await _userService.SendMessageAsync(createMessageVM);
            return RedirectToAction(nameof(Index));
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
            await _userService.PaymentAsync(payment.CreditCard, (int)TempData["InvoiceId"]);
            return RedirectToAction(nameof(Index));
        }
    }
}