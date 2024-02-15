using BaconsaleMovies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BaconsaleMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext;
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
            return View();
        }
        [HttpPost]
        public IActionResult EnterMovie(Movie movie) 
        {
            // Inserting movie to DB on Post
            _movieContext.Add(movie);
            _movieContext.SaveChanges();
            // Rendering the view with the movie
            return View(movie);
        }
    }
}
