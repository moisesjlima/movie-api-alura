using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

public class UpdateMovieDto
{
    [Required(ErrorMessage = "field title is required")]
    [StringLength(60, ErrorMessage = "max length 60")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "field genre is required")]
    [StringLength(60, ErrorMessage = "max length 60")]
    public string Genre { get; set; } = string.Empty;

    [Required(ErrorMessage = "field duration is required")]
    [Range(50, 600, ErrorMessage = "duration must be between 50 and 600")]
    public int Duration { get; set; }
}