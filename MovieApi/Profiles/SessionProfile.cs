using AutoMapper;
using MovieApi.Data.DTO;
using MovieApi.Models;

namespace MovieApi.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, ReadSessionDTO>();
    }
}
