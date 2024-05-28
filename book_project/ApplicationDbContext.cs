using Microsoft.EntityFrameworkCore;
using book_project.Models;

namespace book_project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Favourite>()
                .HasKey(f => new { f.UserId, f.BookId });

            // modelBuilder.Entity<Favourite>()
            //     .HasOne(f => f.User)
            //     .WithMany(u => u.Favourites)
            //     .HasForeignKey(f => f.UserId);

            // modelBuilder.Entity<Favourite>()
            //     .HasOne(f => f.Book)
            //     .WithMany(b => b.Favourites)
            //     .HasForeignKey(f => f.BookId);
        }
    }
}
