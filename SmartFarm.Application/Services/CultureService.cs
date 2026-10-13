namespace SmartFarm.Application.Services;

using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using SmartFarm.Domain.Exceptions;

public class CultureService
{
    private readonly IGenericRepository<Culture> _repository;

    public CultureService(IGenericRepository<Culture> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CultureDto>> GetAllAsync()
    {
        var cultures = await _repository.GetAllAsync();
        return cultures.Select(c => new CultureDto(c.Id, c.Nom, c.Variete, c.ParcelleId));
    }

    public async Task<Guid> CreateAsync(CreateCultureDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nom))
            throw new BusinessRuleException("Le nom de la culture est obligatoire.");

        var culture = new Culture
        {
            Id = Guid.NewGuid(),
            Nom = dto.Nom,
            Variete = dto.Variete,
            ParcelleId = dto.ParcelleId
        };

        await _repository.AddAsync(culture);
        return culture.Id;
    }
}