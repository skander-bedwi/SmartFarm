namespace SmartFarm.Application.Services;

using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;

public class MesureCapteurService
{
    private readonly IGenericRepository<MesureCapteur> _repository;

    public MesureCapteurService(IGenericRepository<MesureCapteur> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MesureCapteurDto>> GetAllAsync()
    {
        var mesures = await _repository.GetAllAsync();
        return mesures.Select(m => new MesureCapteurDto(m.Id, m.Temperature, m.Humidite, m.DateMesure, m.ParcelleId));
    }

    public async Task<Guid> CreateAsync(CreateMesureCapteurDto dto)
    {
        var mesure = new MesureCapteur
        {
            Id = Guid.NewGuid(),
            Temperature = dto.Temperature,
            Humidite = dto.Humidite,
            DateMesure = DateTime.UtcNow,
            ParcelleId = dto.ParcelleId
        };

        await _repository.AddAsync(mesure);
        return mesure.Id;
    }
}