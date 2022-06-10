using Locadora.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDTO>> GetAllAsync();
        Task<FilmDTO> GetByIdAsync(int id);
        Task CreateAsync(FilmDTO FilmDTO);
        Task UpdateAsync(FilmDTO FilmDTO);
    }
}
