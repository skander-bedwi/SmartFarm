namespace SmartFarm.Application.Interfaces;

using SmartFarm.Domain.Entities;

public interface IInterventionRepository
{
    Task<IEnumerable<Intervention>> GetAllAsync();
    Task AddAsync(Intervention intervention);
}