using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Payment.API.DTOs
{
    public class PaymentDto
    {
        public CreditCardDto CreditCard { get; set; }
        public decimal Price { get; set; }

    }
}
