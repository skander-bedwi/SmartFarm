namespace SmartFarm.Application.Interfaces;

using SmartFarm.Domain.Entities;

public interface ICultureRepository
{
    Task<Culture?> GetByIdAsync(Guid id);
    Task<IEnumerable<Culture>> GetAllAsync();
    Task AddAsync(Culture culture);
}