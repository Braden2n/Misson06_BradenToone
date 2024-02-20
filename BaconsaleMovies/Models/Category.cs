using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaconsaleMovies.Models
{
    // Category Model
    public class CategoryModel
    {
        [Key]
        [Required(ErrorMessage = "CategoryId is a required field")]
        public required int CategoryId { get; set; }
        [Required(ErrorMessage = "Category is a required field")]
        public required string Category { get; set; }
    }
}
