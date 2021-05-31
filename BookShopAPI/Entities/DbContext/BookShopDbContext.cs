using Microsoft.EntityFrameworkCore;

namespace BookShopAPI.Entities.DbContext
{
    public class BookShopDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<BookShop> BookShops { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BookShopModelCreating(modelBuilder);
            BookModelCreating(modelBuilder);
            AddressModelCreating(modelBuilder);
        }

        private void AddressModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .HasMaxLength(100);
        }

        private void BookModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(6, 2);
        }

        private void BookShopModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookShop>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
