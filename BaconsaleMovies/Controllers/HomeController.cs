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
            return _movieContext.Categories.ToList();
        }
        private List<string?> getRatings()
        {
            return _movieContext.Movies
                .Where(m => m.Rating != null)
                .Select(m => m.Rating)
                .Distinct()
                .ToList();
        }
        private List<Movie> getMovies()
        {
            return _movieContext.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();
        }
        private Movie getMovie(int id)
        {
            return _movieContext.Movies
                .Single(m => m.MovieId == id);
        }
        private void prepViewBag(bool isUpdating = false)
        {
            ViewBag.Categories = getCategories();
            ViewBag.Ratings = getRatings();
            ViewBag.isUpdating = isUpdating;
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
            // Getting Categories and Ratings
            prepViewBag();
            return View("MovieForm");
        }
        [HttpPost]
        public IActionResult EnterMovie(Movie movie) 
        {
            if (ModelState.IsValid)
            {
                // Inserting movie to DB on Post
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                //Getting Categories and Ratings
                prepViewBag();
                // Rendering the view with the movie
                return View("MovieForm", movie);
            }
            else
            {
                return View("MovieForm", movie);
            }
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            List<Movie> Movies = getMovies();
            return View(Movies);
        }
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            Movie movie = getMovie(id);
            // Getting Categories and Ratings
            prepViewBag(true);
            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(movie);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                return View("MovieForm", movie);
            }
        }
        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = getMovie(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult DeleteMove(Movie movie)
        {
            _movieContext.Remove(movie);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
