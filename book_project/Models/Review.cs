using System.ComponentModel.DataAnnotations;

namespace book_project.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int Rating { get; set; }

        public string Analysis { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
