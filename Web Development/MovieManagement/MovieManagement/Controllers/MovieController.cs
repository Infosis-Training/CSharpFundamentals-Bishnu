using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
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

        public IActionResult Index()
        {   
            var movies = _db.Movies.Include(x => x.Genre).ToList();

            var movieViewModels = movies.Select(x => new MovieViewModel()
            {
                Name = x.Name,
                Description = x.Description,
                Genre = x.Genre?.Name ?? "N/A",
                LengthInMin = x.LengthInMin,
                ReleaseDate = x.ReleaseDate,
                BannerDataUrl = $"data:image/png;base64,{Convert.ToBase64String(x.Banner)}",
                Code = x.Code,
                Id = x.Id
            }).ToList();

            return View(movieViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {               
            var genres = await _db.Genre.ToListAsync();
            var genresItems = genres.Select(x => 
                new SelectListItem 
                { 
                    Text = x.Name, 
                    Value = x.Id.ToString() 
                }).ToList();

            genresItems.Add(new SelectListItem { Text = "Choose gender...", Value = "", Selected = true});

            MovieViewModel movieViewModel = new();
            movieViewModel.Genres = genresItems;

            return View(movieViewModel);
        }

        [HttpPost]
        public IActionResult Add(MovieViewModel movieViewModel)
        {   
            Movie movie = new()
            {
                Name = movieViewModel.Name,
                Description = movieViewModel.Description,
                GenreId = int.Parse(movieViewModel.Genre),
                LengthInMin = movieViewModel.LengthInMin,
                ReleaseDate = movieViewModel.ReleaseDate,
            };

            movie.Code = Guid.NewGuid().ToString();

            var stream = new MemoryStream();
            movieViewModel.Banner?.CopyTo(stream);
            movie.Banner = stream.ToArray();

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
