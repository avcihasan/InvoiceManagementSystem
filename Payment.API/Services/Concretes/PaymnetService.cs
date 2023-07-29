using MongoDB.Driver;
using Payment.API.DTOs;
using Payment.API.Entities;
using Payment.API.Services.Abstractions;
using Payment.API.Settings;

namespace Payment.API.Services.Concretes
{
    public class PaymnetService : IPaymnetService
    {
        readonly IMongoCollection<CreditCard> _creditCardCollection;

        public PaymnetService(IDatabaseSettings databaseSettings)
        {
            MongoClient client = new(databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            _creditCardCollection = database.GetCollection<CreditCard>(databaseSettings.CreditCardCollectionName);
        }

        public async Task<ResponseDto> PaymentAsync(PaymentDto paymentDto)
        {
            CreditCard creditCard = await _creditCardCollection.Find(x => x.Cvv == paymentDto.CreditCard.Cvv && x.CardNumber==paymentDto.CreditCard.CardNumber && x.ExpirationDate==paymentDto.CreditCard.ExpirationDate).FirstOrDefaultAsync();
            if (creditCard is null)
                return new() { IsSuccess = false, Description = "Hata Oluştu" };
            if(creditCard.Balance<paymentDto.Price)
                return new() { IsSuccess = false, Description = "Bakiye Yetersiz" };

            creditCard.Balance -= paymentDto.Price;
            ReplaceOneResult result = _creditCardCollection.ReplaceOne(x => x.Id == creditCard.Id, creditCard);
            if(result.ModifiedCount<=0)
                return new() { IsSuccess = false, Description = "Hata Oluştu" };
            return new() { IsSuccess = true, Description = "İşlem Başarılı" };
        }

        public async Task xxx()
        {
          await  _creditCardCollection.InsertOneAsync(new() { CardNumber="4444-4444",Balance=5000,CardType="Master",
          Cvv="444",ExpirationDate="11/2023"});
        }
    }

}
