using Locadora.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IRentService
    {
        Task<IEnumerable<RentDTO>> GetAllAsync();
        Task<RentDTO> GetByIdAsync(int id);
        Task CreateAsync(RentDTO RentDTO);
        Task UpdateAsync(RentDTO RentDTO);
    }
}
