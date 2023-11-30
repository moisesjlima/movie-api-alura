using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class CreateMovieTheaterDto
    {
        [Required(ErrorMessage = "name field is required!")]
        public string Name { get; set; }
    }
}