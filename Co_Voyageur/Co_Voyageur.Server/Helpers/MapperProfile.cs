using AutoMapper;
using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();
    }
}