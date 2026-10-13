namespace SmartFarm.Application.Services;

using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Domain.Exceptions;

public class PlantationService
{
    private readonly IGenericRepository<Plantation> _repository;

    public PlantationService(IGenericRepository<Plantation> repository)
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
        if (dto.DateRecoltePrevue.HasValue && dto.DateRecoltePrevue <= dto.DatePlantation)
            throw new BusinessRuleException("La date de recolte prevue doit etre apres la date de plantation.");

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