using MovieManagement.Helpers;
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
                GenreId = movie.Genre?.Id,
                GenreName = movie.Genre?.Name ?? "N/A",
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
                Id = movieViewModel.Id,
                Name = movieViewModel.Name,
                GenreId = movieViewModel.GenreId,
                Description = movieViewModel.Description ?? "N/A",
                LengthInMin = movieViewModel.LengthInMin,
                ReleaseDate = movieViewModel.ReleaseDate,
                Code = Guid.NewGuid().ToString()
            };

            var stream = new MemoryStream();
            movieViewModel.Banner?.CopyTo(stream);
            movie.Banner = stream.ToArray();

            return movie;
        }

        public static PaginationList<MovieViewModel> ToPaginatedViewModels(
            this PaginationList<Movie> models)
        {
            var pList = new PaginationList<MovieViewModel>();

            if (!models.Any())
                return pList;

            pList.PageIndex = models.PageIndex;
            pList.TotalPages = models.TotalPages;

            var viewModels = models.Select(x => x.ToViewModel());
            pList.AddRange(viewModels);

            return pList;
        }
    }
}
