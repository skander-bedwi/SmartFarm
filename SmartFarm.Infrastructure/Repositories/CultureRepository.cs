namespace SmartFarm.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Infrastructure.Persistence;

public class CultureRepository : ICultureRepository
{
    private readonly SmartFarmDbContext _context;

    public CultureRepository(SmartFarmDbContext context)
    {
        _context = context;
    }

    public async Task<Culture?> GetByIdAsync(Guid id)
    {
        return await _context.Cultures.FindAsync(id);
    }

    public async Task<IEnumerable<Culture>> GetAllAsync()
    {
        return await _context.Cultures.ToListAsync();
    }

    public async Task AddAsync(Culture culture)
    {
        await _context.Cultures.AddAsync(culture);
        await _context.SaveChangesAsync();
    }
}