using AutoMapper;
using Locadora.Application.DTOs;
using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
