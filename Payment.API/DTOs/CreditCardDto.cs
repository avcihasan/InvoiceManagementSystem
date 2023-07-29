using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Payment.API.DTOs
{
    public class CreditCardDto
    {
        public string Id { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Balance { get; set; }
    }
}
