namespace SmartFarm.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Infrastructure.Persistence;

public class IrrigationRepository : IIrrigationRepository
{
    private readonly SmartFarmDbContext _context;

    public IrrigationRepository(SmartFarmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Irrigation>> GetAllAsync()
    {
        return await _context.Irrigations.ToListAsync();
    }

    public async Task AddAsync(Irrigation irrigation)
    {
        await _context.Irrigations.AddAsync(irrigation);
        await _context.SaveChangesAsync();
    }
}