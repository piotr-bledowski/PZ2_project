using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace book_project.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        //public ICollection<Book> Books { get; set; }
    }
}
