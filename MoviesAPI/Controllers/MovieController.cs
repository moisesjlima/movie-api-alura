using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private static List<Movie> movies = new List<Movie>();
    private static int Id = 0;

    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
        movie.MovieId = ++Id;
        movies.Add(movie);
        Console.WriteLine("Title: " + movie.Title);
        Console.WriteLine("Duration: " + movie.Duration);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return movies;
    }

    [HttpGet("{id}")]
    public Movie GetMoviesById([FromRoute] int id)
    {
        return movies.FirstOrDefault(x => x.MovieId == id)!;
    }
}