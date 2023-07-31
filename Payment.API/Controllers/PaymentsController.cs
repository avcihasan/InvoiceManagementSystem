using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.DTOs;
using Payment.API.Services.Abstractions;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        readonly IPaymnetService _paymnetService;

        public PaymentsController(IPaymnetService paymnetService)
        {
            _paymnetService = paymnetService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaymentDto paymentDto)
        {
            return Ok(await _paymnetService.PaymentAsync(paymentDto));
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            return Ok(await _paymnetService.xxx());
        }
    }
}
