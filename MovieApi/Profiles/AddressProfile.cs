using AutoMapper;
using MovieApi.Data.DTO;
using MovieApi.Models;

namespace MovieApi.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDTO, Address>();
        CreateMap<UpdateAdressDTO, Address>();
        CreateMap<Address, ReadAddressDTO>();
    }
}
