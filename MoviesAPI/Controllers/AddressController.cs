using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDto enderecoDto)
    {
        Address address = _mapper.Map<Address>(enderecoDto);

        _context.Addresses.Add(address);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAddressById), new { addressId = address.AddressId }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses()
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses);
    }

    [HttpGet("{addressId}")]
    public IActionResult GetAddressById(int addressId)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == addressId);
        if (address != null)
        {
            ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
            return Ok(addressDto);
        }

        return NotFound();
    }

    [HttpPut("{addressId}")]
    public IActionResult UpdateAddress(int addressId, [FromBody] UpdateAddressDto enderecoDto)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == addressId);
        if (address == null)
            return NotFound();

        _mapper.Map(enderecoDto, address);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{addressId}")]
    public IActionResult DeleteAddress(int addressId)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == addressId);
        if (address == null)
        {
            return NotFound();
        }

        _context.Remove(address);
        _context.SaveChanges();

        return NoContent();
    }
}