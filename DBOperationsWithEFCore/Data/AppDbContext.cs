using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Adding data to tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adding data in Currency table
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian INR"},
                new Currency() { Id = 2, Title = "Dollar", Description = "Dollar"},
                new Currency() { Id = 3, Title = "Euro", Description = "Euro"},
                new Currency() { Id = 4, Title = "Dinar", Description = "Dinar"}
            );

            // Adding data to Language table
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Hindi"},
                new Language() { Id = 2, Title = "Tamil", Description = "Tamil"},
                new Language() { Id = 3, Title = "Punjabi", Description = "Punjabi"},
                new Language() { Id = 4, Title = "Urdu", Description = "Urdu"}
            );

            // Configure the relationship between Book and Language
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Language)  // A Book has one Language
                .WithMany()               // Language can have many Books (optional)
                .HasForeignKey(b => b.LanguageId); // The foreign key is LanguageId
        }


        public DbSet<Book> Books{get; set;}
        public DbSet<Language> Languages{ get; set;}
        public DbSet<BookPrice> BookPrices{ get; set;}
        public DbSet<Currency> Currencies{ get; set;}
        public DbSet<Author> Authors{ get; set;}

    }
}
