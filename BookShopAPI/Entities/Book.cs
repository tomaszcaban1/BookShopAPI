namespace BookShopAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ClassifiedInformation { get; set; }
        public int BookShopId { get; set; }
        public virtual BookShop BookShop { get; set; }

    }
}