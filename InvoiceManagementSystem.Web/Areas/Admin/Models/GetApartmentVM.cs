namespace InvoiceManagementSystem.Web.Areas.Admin.Models
{
    public class GetApartmentVM
    {
        public string Id { get; set; }
        public int ApartmentNumber { get; set; }
        public int BlockNumber { get; set; }
        public bool Situation { get; set; }
        public string Type { get; set; }
        public int FloorLocation { get; set; }
        public bool Tenant { get; set; }
    }
}
