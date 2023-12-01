using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public SessionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSession(CreateSessionDto dto)
    {
        Session session = _mapper.Map<Session>(dto);

        _context.Sessions.Add(session);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetSessionById), new { sessionId = session.SessionId }, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> GetSessions()
    {
        return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
    }

    [HttpGet("{sessionId}")]
    public IActionResult GetSessionById(int sessionId)
    {
        Session session = _context.Sessions.FirstOrDefault(session => session.SessionId == sessionId);
        if (session != null)
        {
            ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);
            return Ok(sessionDto);
        }

        return NotFound();
    }
}