namespace BookShopAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public virtual BookShop BookShop { get; set; }
    }
}