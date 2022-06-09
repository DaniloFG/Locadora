using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.InfraData.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.InfraData.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public Task<Client> CreateAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
