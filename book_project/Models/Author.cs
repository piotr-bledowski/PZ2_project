using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReviewPlatform.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
