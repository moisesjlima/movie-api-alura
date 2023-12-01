using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

public class UpdateMovieTheaterDto
{
    [Required(ErrorMessage = "name field is required!")]
    public string Name { get; set; }
}