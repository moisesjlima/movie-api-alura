using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public int MovieTheaterId { get; set; }

        [Required(ErrorMessage = "name field is required!")]
        public string Name { get; set; }
    }
}