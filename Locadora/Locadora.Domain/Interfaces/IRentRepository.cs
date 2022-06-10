using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IRentRepository
    {
        Task<ICollection<Rent>> GetAllAsync();
        Task<Rent> GetByIdAsync(int? id);
        Task<Rent> CreateAsync(Rent rent);
        Task<Rent> UpdateAsync(Rent rent);
    }
}
