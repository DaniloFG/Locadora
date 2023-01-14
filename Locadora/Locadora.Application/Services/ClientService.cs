using AutoMapper;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ClientDTO ClientDTO)
        {
            var clientDocument = await _repository.GetAllAsync();

            if (clientDocument.Any(c => c.Document == ClientDTO.Document))
                throw new InvalidOperationException("Error, document is alredy exists");

            var clientEntity = _mapper.Map<Client>(ClientDTO);
            await _repository.CreateAsync(clientEntity);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            var clientEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(clientEntity);
        }

        public async Task<ClientDTO> GetByIdAsync(int id)
        {
            var clientEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(clientEntity);
        }

        public async Task UpdateAsync(ClientDTO ClientDTO)
        {
            var clientEntity = _mapper.Map<Client>(ClientDTO);
            await _repository.UpdateAsync(clientEntity);
        }
    }
}
