namespace SmartFarm.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Infrastructure.Persistence;

public class PlantationRepository : IPlantationRepository
{
    private readonly SmartFarmDbContext _context;

    public PlantationRepository(SmartFarmDbContext context)
    {
        _context = context;
    }

    public async Task<Plantation?> GetByIdAsync(Guid id)
    {
        return await _context.Plantations.FindAsync(id);
    }

    public async Task<IEnumerable<Plantation>> GetAllAsync()
    {
        return await _context.Plantations.ToListAsync();
    }

    public async Task AddAsync(Plantation plantation)
    {
        await _context.Plantations.AddAsync(plantation);
        await _context.SaveChangesAsync();
    }
}