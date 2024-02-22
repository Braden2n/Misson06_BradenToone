using BaconsaleMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BaconsaleMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext;
        private List<CategoryModel> getCategories()
        {
            // Gets all distinct categories
            return _movieContext.Categories
                .Distinct()
                .ToList();
        }
        private List<string?> getRatings()
        {
            // Gets all distinct non-null ratings from movies
            return _movieContext.Movies
                .Where(m => m.Rating != null)
                .Select(m => m.Rating)
                .Distinct()
                .ToList();
        }
        private List<Movie> getMovies()
        {
            // Gets all movies with joined category ordered by title
            return _movieContext.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();
        }
        private Movie getMovie(int id)
        {
            // Gets a single movie by its MovieId
            return _movieContext.Movies
                .Single(m => m.MovieId == id);
        }
        // Called before every render of the MovieForm view
        private void prepViewBag(bool isUpdating = false, bool submitAgain = false)
        {
            // Categories and Ratings added to View bag
            ViewBag.Categories = getCategories();
            ViewBag.Ratings = getRatings();
            // Used when editing an existing movie
            ViewBag.isUpdating = isUpdating;
            // Used when returning to the page after a successful addition
            ViewBag.submitAgain = submitAgain;
        }
        public HomeController(MovieContext movieContext)
        {
            // Constructor for SQLite context
            _movieContext = movieContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterMovie()
        {
            prepViewBag();
            // new Movie() added to use autoincremented numbers in form
            return View("MovieForm", new Movie());
        }
        [HttpPost]
        public IActionResult EnterMovie(Movie movie) 
        {
            if (ModelState.IsValid)
            {
                // Inserting movie to DB on Post
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                // Setting custom ViewBag Properties
                prepViewBag(false, true);
                // new Movie() to use autoincremented numbers
                return View("MovieForm", new Movie());
            }
            else
            {
                // Returning on failed validation
                prepViewBag();
                return View("MovieForm", movie);
            }
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            // List of all movies sent to view
            List<Movie> Movies = getMovies();
            return View(Movies);
        }
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            // Specific movie loaded by id
            Movie movie = getMovie(id);
            // Setting custom ViewBag Properties
            prepViewBag(true);
            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Updating and saving from POST
                _movieContext.Update(movie);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                // Returning to view on failed validation
                return View("MovieForm", movie);
            }
        }
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            // Getting movie by id
            Movie movie = getMovie(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            // Confirmation won't change Model - always valid
            // Deleting and saving movie on POST
            _movieContext.Remove(movie);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
