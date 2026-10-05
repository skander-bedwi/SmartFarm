using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFarm.Infrastructure.Repositories
{
    public class ParcelleRepository : IParcelleRepository
    {
        private readonly SmartFarmDbContext _context;

        public ParcelleRepository(SmartFarmDbContext context)
        {
            _context = context;
        }

        public async Task<Parcelle?> GetByIdAsync(Guid id)
        {
            return await _context.Parcelles.FindAsync(id);
        }

        public async Task<IEnumerable<Parcelle>> GetAllAsync()
        {
            return await _context.Parcelles.ToListAsync();
        }

        public async Task AddAsync(Parcelle parcelle)
        {
            await _context.Parcelles.AddAsync(parcelle);
            await _context.SaveChangesAsync();
        }
    }
}
