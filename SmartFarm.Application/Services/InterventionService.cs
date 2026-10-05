namespace SmartFarm.Application.Services;

using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;

public class InterventionService
{
    private readonly IInterventionRepository _repository;

    public InterventionService(IInterventionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InterventionDto>> GetAllAsync()
    {
        var interventions = await _repository.GetAllAsync();
        return interventions.Select(i => new InterventionDto(i.Id, i.Type, i.Description, i.DateIntervention, i.ParcelleId));
    }

    public async Task<Guid> CreateAsync(CreateInterventionDto dto)
    {
        var intervention = new Intervention
        {
            Id = Guid.NewGuid(),
            Type = dto.Type,
            Description = dto.Description,
            DateIntervention = DateTime.UtcNow,
            ParcelleId = dto.ParcelleId
        };

        await _repository.AddAsync(intervention);
        return intervention.Id;
    }
}