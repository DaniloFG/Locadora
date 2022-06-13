using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IFilmRepository
    {
        Task<ICollection<Film>> GetAllAsync();
        Task<Film> GetByIdAsync(int id);
        Task<Film> CreateAsync(Film client);
        Task<Film> UpdateAsync(Film client);
    }
}
