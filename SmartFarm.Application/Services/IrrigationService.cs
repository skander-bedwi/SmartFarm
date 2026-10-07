namespace SmartFarm.Application.Services;

using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;

public class IrrigationService
{
    private readonly IGenericRepository<Irrigation> _repository;

    public IrrigationService(IGenericRepository<Irrigation> repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<IrrigationDto>> GetAllAsync()
    {
        var irrigations = await _repository.GetAllAsync();
        return irrigations.Select(i => new IrrigationDto(i.Id, i.DateIrrigation, i.VolumeEauLitres, i.Methode, i.ParcelleId));
    }

    public async Task<Guid> CreateAsync(CreateIrrigationDto dto)
    {
        var irrigation = new Irrigation
        {
            Id = Guid.NewGuid(),
            DateIrrigation = DateTime.UtcNow,
            VolumeEauLitres = dto.VolumeEauLitres,
            Methode = dto.Methode,
            ParcelleId = dto.ParcelleId
        };

        await _repository.AddAsync(irrigation);
        return irrigation.Id;
    }
}