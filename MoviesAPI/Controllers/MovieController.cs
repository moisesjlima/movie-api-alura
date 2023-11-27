using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieModel)
    {
        var movie = _mapper.Map<Movie>(movieModel);
        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMoviesById), new { movieId = movie.MovieId }, movie);
    }

    [HttpGet]
    public IEnumerable<CreateMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var movies = _context.Movies.Skip(skip).Take(take);

        return _mapper.Map<IEnumerable<CreateMovieDto>>(movies);
    }

    [HttpGet("{movieId}")]
    public IActionResult GetMoviesById([FromRoute] int movieId)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);

        var movieMap = _mapper.Map<CreateMovieDto>(movie);

        if (movie == null)
            return NotFound();

        return Ok(movieMap);
    }
}