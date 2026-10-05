namespace SmartFarm.Application.DTOs;

public record CultureDto(Guid Id, string Nom, string? Variete, Guid ParcelleId);

public record CreateCultureDto(string Nom, string? Variete, Guid ParcelleId);