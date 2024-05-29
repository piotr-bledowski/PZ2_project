using book_project.Data;
using book_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_project.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(); // Display registration form
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User { UserId = _context.Users.Last().UserId + 1,  UserName = model.Username, PasswordHash = model.Password, Token = model.Password };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home"); // Redirect to login page
            }
            else
            {
                // Add errors from 'result.Errors' to ModelState for display in the view
            }
        }

        return View(model); // Re-render the view with any validation errors
    }

    public IActionResult Login()
    {
        return View(); // Display login form
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            //login
            var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt");
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login","Account");
    }
}
