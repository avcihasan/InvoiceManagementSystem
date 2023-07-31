using InvoiceManagementSystem.Application.Abstractions.Services;
using InvoiceManagementSystem.Application.DTOs.PaymentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
            => Ok(await _paymentService.GetAllPaymentsAsync());

        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] CreditCardDto creditCard, [FromQuery] int invoiceId)
        {
            await _paymentService.PaymentAsync(creditCard, invoiceId);
            return Ok();
        }
    }
}
