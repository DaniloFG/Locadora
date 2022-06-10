using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.InfraData.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Film> CreateAsync(Film client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<ICollection<Film>> GetAllAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film> GetByIdAsync(int? id)
        {
            return await _context.Films.FindAsync(id);
        }

        public async Task<Film> UpdateAsync(Film client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
