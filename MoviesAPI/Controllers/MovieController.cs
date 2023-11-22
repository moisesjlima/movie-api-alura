using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private static List<Movie> movies = new List<Movie>();

    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
        //if (!string.IsNullOrEmpty(movie.Title) && !string.IsNullOrEmpty(movie.Genre) && (movie.Duration > 0 && movie.Duration <= 300))
        //{ }
        movies.Add(movie);
        Console.WriteLine("Title: " + movie.Title);
        Console.WriteLine("Duration: " + movie.Duration);


    }
}