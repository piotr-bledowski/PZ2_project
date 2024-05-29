using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace book_project.Models
{
    public class User  : IdentityUser
    {
        public int UserId { get; set; }

      
        // public string Username { get; set; }

        
        // public string PasswordHash { get; set; }

        public string Token { get; set; }

        // public ICollection<Review> Reviews { get; set; }
        // public ICollection<Favourite> Favourites { get; set; }
    }
}
