using Locadora.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<ICollection<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int? id);
        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
    }
}
