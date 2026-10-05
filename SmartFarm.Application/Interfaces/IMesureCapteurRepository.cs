namespace SmartFarm.Application.Interfaces;

using SmartFarm.Domain.Entities;

public interface IMesureCapteurRepository
{
    Task<IEnumerable<MesureCapteur>> GetAllAsync();
    Task AddAsync(MesureCapteur mesure);
}