using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Data.DTO;
using MovieApi.Models;
using System.Net;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateAddressDTO addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDTO> RecuperaEnderecos()
        {
            return _mapper.Map<List<ReadAddressDTO>>(_context.Address);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDTO addressDto = _mapper.Map<ReadAddressDTO>(address);

                return Ok(addressDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateAdressDTO addressDto)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}