using BaconsaleMovies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BaconsaleMovies.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
        }
    }
}
