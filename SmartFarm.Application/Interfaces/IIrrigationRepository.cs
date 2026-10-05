namespace SmartFarm.Application.Interfaces;

using SmartFarm.Domain.Entities;

public interface IIrrigationRepository
{
    Task<IEnumerable<Irrigation>> GetAllAsync();
    Task AddAsync(Irrigation irrigation);
}