using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.InfraData.Repository
{
    public class RentRepository : IRentRepository
    {
        AppDbContext _context;

        public RentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rent> CreateAsync(Rent rent)
        {
            _context.Add(rent);
            await _context.SaveChangesAsync();
            return rent;
        }

        public async Task<ICollection<Rent>> GetAllAsync()
        {
            return await _context.Rents.ToListAsync();
        }

        public async Task<Rent> GetByIdAsync(int id)
        {
            return await _context.Rents.FindAsync(id);
        }

        public async Task<Rent> UpdateAsync(Rent rent)
        {
            _context.Update(rent);
            await _context.SaveChangesAsync();
            return rent;
        }
    }
}
