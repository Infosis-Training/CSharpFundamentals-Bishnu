using MovieManagement.Models;
using MovieManagement.ViewModels;

namespace MovieManagement.Mapper
{
    public static class MovieMapper
    {
        public static MovieViewModel ToViewModel(this Movie movie)
        {
            return new MovieViewModel
            {
                Name = movie.Name,
                Description = movie.Description,
                Genre = movie.Genre?.Name ?? "N/A",
                LengthInMin = movie.LengthInMin,
                ReleaseDate = movie.ReleaseDate,
                BannerDataUrl = $"data:image/png;base64,{Convert.ToBase64String(movie.Banner)}",
                Code = movie.Code,
                Id = movie.Id
            };
        }

        public static Movie ToModel(this MovieViewModel movieViewModel)
        {
            var movie = new Movie
            {
                Name = movieViewModel.Name,
                Description = movieViewModel.Description ?? "N/A",                
                LengthInMin = movieViewModel.LengthInMin,
                ReleaseDate = movieViewModel.ReleaseDate,
                Code = Guid.NewGuid().ToString()
            };

            int.TryParse(movieViewModel.Genre, out int genreId);
            movie.GenreId = genreId == default ? null : genreId;

            var stream = new MemoryStream();
            movieViewModel.Banner?.CopyTo(stream);
            movie.Banner = stream.ToArray();

            return movie;
        }
    }
}
