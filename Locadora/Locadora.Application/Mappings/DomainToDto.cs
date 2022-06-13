using AutoMapper;
using Locadora.Application.DTOs;
using Locadora.Domain.Entities;

namespace Locadora.Application.Mappings
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Film, FilmDTO>().ReverseMap();
            CreateMap<Rent, RentDTO>().ReverseMap();
        }
    }
}
