using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaconsaleMovies.Models
{
    // Movie model
    public class Movie
    {
        [Key]
        [Required(ErrorMessage = "MovieId is a required field")]
        public required int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "Title is a required field")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Year is a required field")]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be 1888 or greater")]
        public required int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited is a required field")]
        public required bool Edited { get; set; } = false;
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "CopiedToPlex is a required field")]
        public required bool CopiedToPlex { get; set; } = false;
        public string? Notes { get; set; }
    }
}
