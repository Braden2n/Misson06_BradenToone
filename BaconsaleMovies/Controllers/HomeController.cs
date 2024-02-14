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
            _movieContext.Add(movie);
            _movieContext.SaveChanges();
            return View(movie);
        }
    }
}
