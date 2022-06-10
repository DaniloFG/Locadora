using Locadora.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllAsync();
        Task<ClientDTO> GetByIdAsync(int id);
        Task CreateAsync(ClientDTO ClientDTO);
        Task UpdateAsync(ClientDTO ClientDTO);
    }
}
