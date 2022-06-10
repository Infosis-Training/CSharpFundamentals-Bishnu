using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models;
using System.Collections.Generic;

namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {            
            Movie movie1 = new()
            {
                Name = "3 Idiots",
                Code = "A1BC56",
                Genre = "Comedy",
                Description = "Movie based on real story",
                LengthInMin = 178,
                ReleaseDate = DateTime.Parse("2015-01-01")
            };
            
            Movie movie2 = new()
            {
                Name = "KGF",
                Code = "D1BC897",
                Genre = "Action Drama",
                Description = "Movie based on gold smuggling",
                LengthInMin = 167,
                ReleaseDate = DateTime.Parse("2021-04-12")
            };
            Movie movie3 = new()
            {
                Name = "KGF",
                Code = "D1BC897",
                Genre = "Action Drama",
                Description = "Movie based on gold smuggling",
                LengthInMin = 167,
                ReleaseDate = DateTime.Parse("2021-04-12")
            };
            Movie movie4 = new()
            {
                Name = "KGF",
                Code = "D1BC897",
                Genre = "Action Drama",
                Description = "Movie based on gold smuggling",
                LengthInMin = 167,
                ReleaseDate = DateTime.Parse("2021-04-12")
            };

            List<Movie> movies = new() { movie1, movie2, movie3, movie4 };

            return View(movies);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
