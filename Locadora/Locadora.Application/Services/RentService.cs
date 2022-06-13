using AutoMapper;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class RentService : IRentService
    {
        private IClientRepository _repositoryClient;
        private IFilmRepository _repositoryFilm;
        private IRentRepository _repositoryRent;
        private readonly IMapper _mapper;

        public RentService(IClientRepository repositoryClient, IFilmRepository repositoryFilm, IRentRepository repositoryRent, IMapper mapper)
        {
            _repositoryClient = repositoryClient;
            _repositoryFilm = repositoryFilm;
            _repositoryRent = repositoryRent;
            _mapper = mapper;
        }

        public async Task CreateAsync(RentDTO RentDTO)
        {
            var rentEntity = _mapper.Map<Rent>(RentDTO);
            await _repositoryRent.CreateAsync(rentEntity);
        }

        public async Task<IEnumerable<RentDTO>> GetAllAsync()
        {
            var rentEntity = await _repositoryRent.GetAllAsync();
            return _mapper.Map<IEnumerable<RentDTO>>(rentEntity);
        }

        public async Task<RentDTO> GetByIdAsync(int id)
        {
            var rentEntity = await _repositoryRent.GetByIdAsync(id);
            return _mapper.Map<RentDTO>(rentEntity);
        }

        public async Task UpdateAsync(RentDTO RentDTO)
        {
            var rentEntity = _mapper.Map<Rent>(RentDTO);
            await _repositoryRent.UpdateAsync(rentEntity);
        }
    }
}
