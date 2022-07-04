namespace MovieManagement.Api.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public float LengthInMin { get; set; }
        public byte[]? Banner { get; set; }
    }
}
