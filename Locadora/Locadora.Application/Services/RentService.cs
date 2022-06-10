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
        private readonly IRentRepository _repository;
        private readonly IMapper _mapper;

        public RentService(IRentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(RentDTO RentDTO)
        {
            var rentEntity = _mapper.Map<Rent>(RentDTO);
            await _repository.CreateAsync(rentEntity);
        }

        public async Task<IEnumerable<RentDTO>> GetAllAsync()
        {
            var rentEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RentDTO>>(rentEntity);
        }

        public async Task<RentDTO> GetByIdAsync(int id)
        {
            var rentEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<RentDTO>(rentEntity);
        }

        public async Task UpdateAsync(RentDTO RentDTO)
        {
            var rentEntity = _mapper.Map<Rent>(RentDTO);
            await _repository.UpdateAsync(rentEntity);
        }
    }
}
