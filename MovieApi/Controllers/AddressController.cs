using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Data.DTO;
using MovieApi.Models;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public AddressController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDTO addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecoverAddressById), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDTO> RecoverAddress()
        {
            return _mapper.Map<List<ReadAddressDTO>>(_context.Address);
        }

        [HttpGet("{id}")]
        public IActionResult RecoverAddressById(int id)
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
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAdressDTO addressDto)
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
        public IActionResult DeleteAddress(int id)
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