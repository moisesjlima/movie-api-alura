using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MovieTheaterController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovieTheater([FromBody] CreateMovieTheaterDto movieTheaterDto)
    {
        MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);

        _context.MovieTheaters.Add(movieTheater);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieTheaterById), new { movieTheaterId = movieTheater.MovieTheaterId }, movieTheater);
    }

    [HttpGet]
    public IEnumerable<ReadMovieTheaterDto> GetMovieTheaters()
    {
        var movieTheaterList = _context.MovieTheaters.ToList();
        return _mapper.Map<List<ReadMovieTheaterDto>>(movieTheaterList);
    }

    [HttpGet("{movieTheaterId}")]
    public IActionResult GetMovieTheaterById(int movieTheaterId)
    {

        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.MovieTheaterId == movieTheaterId);
        if (movieTheater != null)
        {
            ReadMovieTheaterDto movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
            return Ok(movieTheaterDto);
        }

        return NotFound();
    }

    [HttpPut("{movieTheaterId}")]
    public IActionResult UpdateMovieTheater(int movieTheaterId, [FromBody] UpdateMovieTheaterDto movieTheaterDto)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.MovieTheaterId == movieTheaterId);
        if (movieTheater == null)
            return NotFound();


        _mapper.Map(movieTheaterDto, movieTheater);
        _context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{movieTheaterId}")]
    public IActionResult DeleteMovieTheater(int movieTheaterId)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.MovieTheaterId == movieTheaterId);
        if (movieTheater == null)
            return NotFound();


        _context.Remove(movieTheater);
        _context.SaveChanges();

        return NoContent();
    }
}