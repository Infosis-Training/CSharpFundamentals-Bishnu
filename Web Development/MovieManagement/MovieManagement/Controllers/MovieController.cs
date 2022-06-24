using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Mapper;
using MovieManagement.Models;
using MovieManagement.ViewModels;

namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieManagementDb _db;

        public MovieController(MovieManagementDb db) // Dependency Injection
        {
            _db = db;
        }

        public IActionResult Index(string sortOrder)
        {
            var movies = _db.Movies.Include(x => x.Genre).ToList();
            var movieViewModels = new List<MovieViewModel>();

            if (movies.Any())
            {
                movieViewModels = movies.Select(x => x.ToViewModel()).ToList();

            }
            return View(movieViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            MovieViewModel movieViewModel = new()
            {
                Genres = GetGenreSelectListItems()
            };

            return View(movieViewModel);
        }

        [HttpPost]
        public IActionResult Add([FromForm] MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = movieViewModel.ToModel();

                _db.Movies.Add(movie);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(movieViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _db.Movies.Find(id);
            var movieViewModel = movieToEdit.ToViewModel();
            movieViewModel.Genres = GetGenreSelectListItems();

            return View(movieViewModel);
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = movieViewModel.ToModel();

                _db.Movies.Update(movie);
                _db.SaveChanges();
            }

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

        private List<SelectListItem> GetGenreSelectListItems()
        {
            var genres = _db.Genre.ToList();

            var genresItems = genres.Select(x =>
                            new SelectListItem
                            {
                                Text = x.Name,
                                Value = x.Id.ToString()
                            }).ToList();

            genresItems.Add(new SelectListItem { Text = "Choose gender...", Value = "", Selected = true });

            return genresItems;
        }
    }
}
