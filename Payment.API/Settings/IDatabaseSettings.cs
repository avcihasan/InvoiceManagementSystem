namespace Payment.API.Settings
{
    public interface IDatabaseSettings
    {
        public string CreditCardCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
