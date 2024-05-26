using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using book_project.Data;
using book_project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavourites()
        {
            return await _context.Favourites
                .Include(f => f.User)
                .Include(f => f.Book)
                .ToListAsync();
        }

        [HttpGet("{userId}/{bookId}")]
        public async Task<ActionResult<Favourite>> GetFavourite(int userId, int bookId)
        {
            var favourite = await _context.Favourites
                .Include(f => f.User)
                .Include(f => f.Book)
                .FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);

            if (favourite == null)
            {
                return NotFound();
            }

            return favourite;
        }

        [HttpPost]
        public async Task<ActionResult<Favourite>> PostFavourite(Favourite favourite)
        {
            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavourite", new { userId = favourite.UserId, bookId = favourite.BookId }, favourite);
        }

        [HttpDelete("{userId}/{bookId}")]
        public async Task<IActionResult> DeleteFavourite(int userId, int bookId)
        {
            var favourite = await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);
            if (favourite == null)
            {
                return NotFound();
            }

            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

}
