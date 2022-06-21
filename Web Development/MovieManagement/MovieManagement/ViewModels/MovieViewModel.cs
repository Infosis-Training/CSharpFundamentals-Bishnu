using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be of at least 3 chars")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
                
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public float LengthInMin { get; set; }

        public IFormFile Banner { get; set; }
        public string BannerDataUrl { get; set; }

        [Required]
        public string Genre { get; set; } = string.Empty;
        public List<SelectListItem> Genres { get; set; }
    }
}
