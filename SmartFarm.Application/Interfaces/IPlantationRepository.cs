namespace SmartFarm.Application.Interfaces;

using SmartFarm.Domain.Entities;

public interface IPlantationRepository
{
    Task<Plantation?> GetByIdAsync(Guid id);
    Task<IEnumerable<Plantation>> GetAllAsync();
    Task AddAsync(Plantation plantation);
}