using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace book_project.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        // public ICollection<Review> Reviews { get; set; }
        // public ICollection<Favourite> Favourites { get; set; }
    }
}
