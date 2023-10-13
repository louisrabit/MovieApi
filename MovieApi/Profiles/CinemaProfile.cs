using AutoMapper;
using FilmesApi.Data.Dtos;
using MovieApi.Data.DTO;
using MovieApi.Models;

namespace MovieApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>();
    
    }
}
