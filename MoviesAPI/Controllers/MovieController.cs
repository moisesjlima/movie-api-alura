﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);

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

    [HttpPut("{movieId}")]
    public IActionResult UpdateMovie([FromRoute] int movieId, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);

        if (movie == null)
            return NotFound();

        var movieMap = _mapper.Map(movieDto, movie);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{movieId}")]
    public IActionResult PartialUpdateMovie([FromRoute] int movieId, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);

        if (movie == null)
            return NotFound();

        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate))
            return ValidationProblem(ModelState);

        var movieMap = _mapper.Map(movieToUpdate, movie);

        _context.SaveChanges();

        return NoContent();
    }
}