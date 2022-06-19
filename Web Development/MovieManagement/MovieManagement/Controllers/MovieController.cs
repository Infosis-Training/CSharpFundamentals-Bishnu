using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Add()
        {   
            var genres = await _db.Genre.ToListAsync();
            var genreList = genres.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            genreList.Add(new SelectListItem { Text = "Choose gender...", Value = "", Selected = true});
            ViewData["genreList"] = genreList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieViewModel movie)
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
