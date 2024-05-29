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
        Console.WriteLine("YOOOOOOOOOOOOOOO");
        Console.WriteLine(review.Analysis);
        Console.WriteLine(review.Rating);
        Console.WriteLine(review.ReviewId);
        Console.WriteLine(review.UserId);
        Console.WriteLine(review.BookId);

        _context.Add(review);
        _context.SaveChanges();

        return Redirect("reviews/" + review.BookId.ToString());
    }

    //[Authorize]
    [Route("books")]
    public IActionResult Books() {
        var books = _context.Books.ToList();

        return View(books);
    }

    [Route("reviews/{book_id:int}")]
    public IActionResult Reviews(int book_id) {
            var reviews = _context.Reviews.Where(r => r.BookId == book_id).ToList();

            var title = _context.Books.Where(b => b.BookId == reviews[0].BookId).ToList()[0].Title;

            ViewData["book_title"] = title;
            ViewData["book_id"] = book_id;
            
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
