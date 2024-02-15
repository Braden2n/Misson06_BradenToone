using System.ComponentModel.DataAnnotations;

namespace BaconsaleMovies.Models
{
    // Movie model
    public class Movie
    {
        [Key]
        public required int movie_id { get; set; }
        public required string category { get; set; }
        public string? subcategory { get; set; }
        public required string title { get; set; }
        public required string year { get; set; }
        public required string directors { get; set; }
        public required string rating { get; set; }
        public string? edited { get; set; }
        public bool? lent_to { get; set; }
        public string? notes { get; set; }
    }
}
