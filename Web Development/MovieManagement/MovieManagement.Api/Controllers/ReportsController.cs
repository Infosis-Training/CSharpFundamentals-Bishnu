using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Api.Data;
using MovieManagement.Api.Models;

namespace MovieManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly MovieManagementApiContext _context;

        public ReportsController(MovieManagementApiContext context)
        {
            _context = context;
        }

        [HttpGet("moviegenres")]
        public IActionResult Get()
        {
            var query = from movie in _context.Movie
                        join genre in _context.Genres on movie.GenreId equals genre.Id
                        select new { Name = movie.Name, GenreName = genre.Name };

            query = query.OrderBy(x => x.Name);

            var queryString = query.ToQueryString();

            var results = query.ToList();
            
            return Ok(results);
        }

        [HttpGet("moviegenressp")]
        public IActionResult GetSP()
        {
            var results = _context.Database.ExecuteSqlRaw("exec GetMovies");

            return Ok(results);
        }
    }
}
