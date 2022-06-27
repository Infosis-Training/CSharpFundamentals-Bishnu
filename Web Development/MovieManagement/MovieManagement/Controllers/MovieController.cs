using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Helpers;
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

        public IActionResult Index(string searchString, 
            string sortOrder, 
            int pageNumber = 1, 
            int pageSize = 4)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PageNumber"] = pageNumber;

            ViewData["MovieNameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ReleaseDateSortParam"] = sortOrder == "release_date_desc" ? "release_date_asc" : "release_date_desc";
            ViewData["GenreSortParam"] = sortOrder == "genre_desc" ? "genre_asc" : "genre_desc";
            ViewData["CurrentFilter"] = searchString;

            var movies = _db.Movies.Include(x => x.Genre).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Name.Contains(searchString)
                                       || m.Description.Contains(searchString));
            }

            movies = sortOrder switch
            {
                "name_desc" => movies.OrderByDescending(x => x.Name),
                "release_date_desc" => movies.OrderByDescending(x => x.ReleaseDate),
                "release_date_asc" => movies.OrderBy(x => x.ReleaseDate),
                "genre_desc" => movies.OrderByDescending(x => x.Genre.Name),
                "genre_asc" => movies.OrderBy(x => x.Genre.Name),
                _ => movies.OrderBy(x => x.Name)
            };

            var moviesFetched = new PaginationList<Movie>(movies, pageNumber, pageSize);
            
            var list = moviesFetched.ToPaginatedViewModels();

            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            MovieViewModel movieViewModel = new()
            {
                Genres = GetGenreSelectListItems()
            };

            return View(movieViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = movieViewModel.ToModel();

                _db.Movies.Add(movie);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(movieViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _db.Movies.Include(x => x.Genre)
                                        .FirstOrDefault(x => x.Id == id);
            var movieViewModel = movieToEdit?.ToViewModel();
            
            if (movieViewModel != null)
                movieViewModel.Genres = GetGenreSelectListItems();

            return View(movieViewModel);
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel movieViewModel)
        {
            if (movieViewModel != null && ModelState.IsValid)
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
