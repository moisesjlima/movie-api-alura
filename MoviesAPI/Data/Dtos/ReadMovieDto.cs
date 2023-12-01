namespace MoviesAPI.Data.Dtos;

public class ReadMovieDto
{
    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int Duration { get; set; }

    public DateTime ConsultTime { get; set; } = DateTime.Now;
}