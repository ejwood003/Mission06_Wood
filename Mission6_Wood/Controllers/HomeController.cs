// Ethan Wood - Section 2
// HomeController.cs - Handles requests for the home page, add movie form, Get to Know Joel, and errors

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Wood.Models;

namespace Mission6_Wood.Controllers;

public class HomeController : Controller
{
    // DbContext instance injected by the framework; used to read/write movies in the SQLite database
    private AddedMovieContext _context;
    
    // Constructor injection: ASP.NET Core passes AddedMovieContext when creating the controller
    public HomeController(AddedMovieContext temp)
    {
        _context = temp;
    }
    
    // Serves the home page (Index view)
    public IActionResult Index()
    {
        return View();
    }

    // Serves the "Get to Know Joel" page with links to Quick Wits Comedy and Baconsale
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    // GET /Home/Add - Displays the empty add-movie form
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    // POST /Home/Add - Receives form submission; validates, saves to database, then shows confirmation
    [HttpPost]
    public IActionResult Add(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        return View("Confirmation", movie);
    }

    // Error page: disables caching so each error shows current request ID; used by UseExceptionHandler
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}