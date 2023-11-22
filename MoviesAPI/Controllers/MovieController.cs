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
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        movie.MovieId = ++Id;
        movies.Add(movie);

        return CreatedAtAction(nameof(GetMoviesById), new { movieId = movie.MovieId }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return movies.Skip(skip).Take(take);
    }

    [HttpGet("{movieId}")]
    public IActionResult GetMoviesById([FromRoute] int movieId)
    {
        var movie = movies.FirstOrDefault(x => x.MovieId == movieId);

        if (movie == null)
            return NotFound();

        return Ok(movie);
    }
}