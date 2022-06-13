using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.InfraData.Repository
{
    public class ClientRepository : IClientRepository
    {
        private AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<ICollection<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
