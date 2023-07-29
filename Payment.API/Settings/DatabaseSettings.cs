namespace Payment.API.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string CreditCardCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
