using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using book_project.Models;
using book_project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace book_project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("AddReview/{book_id:int}")]
    public IActionResult AddReview(int book_id)
    {
        var title = _context.Books.Where(b => b.BookId == book_id).ToList()[0].Title;

        ViewData["book_title"] = title;

        ViewData["book_id"] = book_id;

        return View();
    }

    [HttpPost]
    [Route("AddReview/{book_id:int}")]
    public IActionResult AddReview(Review review)
    {
        _context.Add(review);
        _context.SaveChanges();

        return Redirect("http://localhost:5210/reviews/" + review.BookId.ToString());
    }

    //[Authorize]
    [Route("books")]
    public IActionResult Books() {
        var books = _context.Books.ToList();

        return View(books);
    }

    [Route("addToFavorites/{book_id:int}")]
    public IActionResult AddToFavorites(int book_id) {
        var favourite = new Favourite {UserId = 1, BookId = book_id};

        _context.Favourites.Add(favourite);
        _context.SaveChanges();

        return Redirect("http://localhost:5210/reviews/" + favourite.BookId.ToString());
    }

    [Route("removeFromFavorites/{book_id:int}")]
    public IActionResult RemoveFromFavorites(int book_id) {
        var favourite = new Favourite {UserId = 1, BookId = book_id};

        _context.Favourites.Remove(favourite);
        _context.SaveChanges();

        return Redirect("http://localhost:5210/reviews/" + favourite.BookId.ToString());
    }

    [Route("reviews/{book_id:int}")]
    public IActionResult Reviews(int book_id) {
            var reviews = _context.Reviews.Where(r => r.BookId == book_id).ToList();

            var title = _context.Books.Where(b => b.BookId == reviews[0].BookId).ToList()[0].Title;

            ViewData["book_title"] = title;
            ViewData["book_id"] = book_id;

            bool favorite = _context.Favourites.Any(x => x.BookId == book_id && x.UserId == 1);

            ViewData["favorite"] = favorite;
            
            return View(reviews);
        }

    [Route("login")]
    public IActionResult Login() {
        return View();
    }

    [Route("register")]
    public IActionResult Register() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
