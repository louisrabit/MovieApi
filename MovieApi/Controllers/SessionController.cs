using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data.DTO;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Controllers;



[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessionController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateSessionDto sessionDto)
    {
        Session session = _mapper.Map<Session>(sessionDto);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecoverSessionById), new { Id = session.Id }, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDTO> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadSessionDTO>>(_context.Sessions);
    }

    [HttpGet("{id}")]
    public IActionResult RecoverSessionById(int id)
    {
        Session session = _context.Sessions.FirstOrDefault(address => address.Id == id);
        if (session != null)
        {
            ReadSessionDTO sessionDto = _mapper.Map<ReadSessionDTO>(session);

            return Ok(sessionDto);
        }
        return NotFound();
    }



    [HttpDelete("{id}")]
    public IActionResult DeletaSession(int id)
    {
        Session session = _context.Sessions.FirstOrDefault(address => address.Id == id);
        if (session == null)
        {
            return NotFound();
        }
        _context.Remove(session);
        _context.SaveChanges();
        return NoContent();
    }

}
