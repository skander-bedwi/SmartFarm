namespace SmartFarm.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Infrastructure.Persistence;

public class MesureCapteurRepository : IMesureCapteurRepository
{
    private readonly SmartFarmDbContext _context;

    public MesureCapteurRepository(SmartFarmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MesureCapteur>> GetAllAsync()
    {
        return await _context.Mesures.ToListAsync();
    }

    public async Task AddAsync(MesureCapteur mesure)
    {
        await _context.Mesures.AddAsync(mesure);
        await _context.SaveChangesAsync();
    }
}