using AutoMapper;
using MovieApi.Models;
using MovieApi.Data.DTO;

namespace MovieApi.Profiles
{
    public class MovieProfile : Profile
    {
        // Mapeamento de um filme DTO para um filme
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Filme>();
            CreateMap<UpdateMovieDTO, Filme>();
            CreateMap<Filme, UpdateMovieDTO>();
        }
    }
}
