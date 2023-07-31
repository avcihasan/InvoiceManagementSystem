using Payment.API.DTOs;
using Payment.API.Entities;

namespace Payment.API.Services.Abstractions
{
    public interface IPaymnetService
    {
        Task<ResponseDto> PaymentAsync(PaymentDto paymentDto);
        Task<CreditCard> xxx();
    }
}
