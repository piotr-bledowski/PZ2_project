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
            
            modelBuilder.Entity<Author>().HasData(new Author {AuthorId = 1, Name = "Philip K. Dick"});
            modelBuilder.Entity<Book>().HasData(new Book {BookId = 1, Title = "Do Androids Dream of Electric Sheep", Genre = "Science Fiction", AuthorId = 1});
            modelBuilder.Entity<Book>().HasData(new Book {BookId = 2, Title = "The Man In The High Castle", Genre = "Alternative History", AuthorId = 1});

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
