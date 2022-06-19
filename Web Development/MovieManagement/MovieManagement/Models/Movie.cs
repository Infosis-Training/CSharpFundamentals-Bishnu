using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Name must be of at least 2 chars")]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        
        [Required]
        public string Genre { get; set; } = string.Empty;
        
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public float LengthInMin { get; set; }
    }
}
