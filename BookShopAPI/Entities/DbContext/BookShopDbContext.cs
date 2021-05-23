    using Microsoft.EntityFrameworkCore;

namespace BookShopAPI.Entities.DbContext
{
    public class BookShopDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly string _connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=BookShopDb;Trusted_Connection=True";

        public DbSet<BookShop> BookShops { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }

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
        }

        private void BookShopModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookShop>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
