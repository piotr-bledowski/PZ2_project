using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using book_project.Data;
using book_project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_project.Controllers
{
    [Route("api/[controller]/{book_id:int}")]
    [ApiController]
    public class ReviewsController : Controller
    {
        //private readonly ApplicationDbContext _context;

        public ReviewsController()
        {
            //_context = context;
        }

        public IActionResult Reviews(int book_id) {
            ViewData["book_id"] = book_id;
            
            return View();
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        // {
        //     return await _context.Reviews
        //         .Include(r => r.User)
        //         .Include(r => r.Book)
        //         .ToListAsync();
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Review>> GetReview(int id)
        // {
        //     var review = await _context.Reviews
        //         .Include(r => r.User)
        //         .Include(r => r.Book)
        //         .FirstOrDefaultAsync(r => r.ReviewId == id);

        //     if (review == null)
        //     {
        //         return NotFound();
        //     }

        //     return review;
        // }

        // [HttpPost]
        // public async Task<ActionResult<Review>> PostReview(Review review)
        // {
        //     _context.Reviews.Add(review);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutReview(int id, Review review)
        // {
        //     if (id != review.ReviewId)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(review).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ReviewExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteReview(int id)
        // {
        //     var review = await _context.Reviews.FindAsync(id);
        //     if (review == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Reviews.Remove(review);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ReviewExists(int id)
        // {
        //     return _context.Reviews.Any(e => e.ReviewId == id);
        // }
    }
}
