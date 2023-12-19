using Microsoft.AspNetCore.Mvc;
using OMDB2.Models;
using System.Diagnostics;

namespace OMDB2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");
        }

        [HttpPost]
        public IActionResult MovieSearchResults(string title)
        {
            Movie result = MovieSearchDAL.GetMovie(title);
            return View("MovieSearch", result);
        }

        [HttpGet]
        public IActionResult MovieNightForm()
        {
            return View("MovieNight");
        }

        [HttpPost]
        public IActionResult MovieNightResults(string title1, string title2, string title3)
        {
            List<Movie> result = new List<Movie>();
            result.Add(MovieSearchDAL.GetMovie(title1));
            result.Add(MovieSearchDAL.GetMovie(title2));
            result.Add(MovieSearchDAL.GetMovie(title3));
            return View("MovieNight", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}