using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>().ReverseMap();
        CreateMap<UpdateAddressDto, Address>().ReverseMap();
        CreateMap<Address, ReadAddressDto>();
    }
}