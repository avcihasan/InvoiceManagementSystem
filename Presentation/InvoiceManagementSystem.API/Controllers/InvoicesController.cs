using InvoiceManagementSystem.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int invoiceId)
            => Ok(await _invoiceService.GetInvoiceByIdAsync(invoiceId));

        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> GetInvoices([FromRoute] string userName)
            => Ok(await _invoiceService.GetInvoicesAsync(userName));

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateInvoice([FromQuery] decimal invoicePrice)
        {
            await _invoiceService.CreateInvoiceAsync(invoicePrice);
            return Ok();
        }
    }
}
