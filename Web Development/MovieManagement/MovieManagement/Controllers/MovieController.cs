using Microsoft.AspNetCore.Mvc;
using MovieManagement.Data;
using MovieManagement.Models;

namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieManagementDb _db;

        public MovieController(MovieManagementDb db) // Dependency Injection
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var movies = _db.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            movie.Code = Guid.NewGuid().ToString();

            _db.Movies.Add(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _db.Movies.Find(id);
            return View(movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {   
            _db.Movies.Update(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _db.Movies.Find(id);
            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
