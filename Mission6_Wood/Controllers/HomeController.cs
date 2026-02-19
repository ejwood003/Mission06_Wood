// Ethan Wood - Section 2
// HomeController.cs - Handles requests for the home page, add movie form, Get to Know Joel, and errors

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Wood.Models;

namespace Mission6_Wood.Controllers;

/// <summary>
/// Handles home, add/edit/delete movie, collection, Get to Know Joel, and error pages.
/// </summary>
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View(new Movie());
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
    
    // Loads all movies with Category included (for displaying category name); returns Collection view
    public IActionResult Collection()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .ToList();
        
        return View(movies);
    }
    
    // GET /Home/Edit/{id} - Loads the movie by id and shows the Add form pre-filled (same form used for add and edit)
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("Add", recordToEdit);
    }

    // POST /Home/Edit - Saves changes from the form and redirects back to the collection
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("Collection");
    }
    
    // GET /Home/Delete/{id} - Shows the delete confirmation page for the given movie
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    // POST /Home/Delete - Removes the movie from the database and redirects to the collection
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("Collection");
    }
}