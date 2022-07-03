using HelloApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HelloApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public List<Movie> Get()
        {
            // ADO.NET
            List<Movie> movies = new List<Movie>();
            SqlConnection connection = new("Server=(localdb)\\mssqllocaldb;Database=MovieDb;Trusted_Connection=True");
            SqlCommand command = new SqlCommand("select * from movies", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Movie movie = new Movie();
                movie.Id = (int)reader[0];
                movie.Name = (string)reader[1];
                movie.Description = (string)reader[2];
                movies.Add(movie);
            }
            reader.Close();
            connection.Close();

            return movies;
        }
    }
}
