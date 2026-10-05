namespace SmartFarm.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Infrastructure.Persistence;

public class InterventionRepository : IInterventionRepository
{
    private readonly SmartFarmDbContext _context;

    public InterventionRepository(SmartFarmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Intervention>> GetAllAsync()
    {
        return await _context.Interventions.ToListAsync();
    }

    public async Task AddAsync(Intervention intervention)
    {
        await _context.Interventions.AddAsync(intervention);
        await _context.SaveChangesAsync();
    }
}