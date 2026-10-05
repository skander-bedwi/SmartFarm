namespace SmartFarm.Application.Services;

using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;

public class PlantationService
{
    private readonly IPlantationRepository _repository;

    public PlantationService(IPlantationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PlantationDto>> GetAllAsync()
    {
        var plantations = await _repository.GetAllAsync();
        return plantations.Select(p => new PlantationDto(p.Id, p.DatePlantation, p.DateRecoltePrevue, p.Statut, p.CultureId));
    }

    public async Task<Guid> CreateAsync(CreatePlantationDto dto)
    {
        var plantation = new Plantation
        {
            Id = Guid.NewGuid(),
            DatePlantation = dto.DatePlantation,
            DateRecoltePrevue = dto.DateRecoltePrevue,
            Statut = dto.Statut ?? "En cours",
            CultureId = dto.CultureId
        };

        await _repository.AddAsync(plantation);
        return plantation.Id;
    }
}