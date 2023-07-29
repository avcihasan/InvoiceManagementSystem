using Payment.API.DTOs;

namespace Payment.API.Services.Abstractions
{
    public interface IPaymnetService
    {
        Task<ResponseDto> PaymentAsync(PaymentDto paymentDto);
        Task xxx();
    }
}
