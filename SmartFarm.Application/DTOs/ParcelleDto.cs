namespace SmartFarm.Application.DTOs;

public record ParcelleDto(Guid Id, string Nom, double SurfaceHectares, string? Localisation);

public record CreateParcelleDto(string Nom, double SurfaceHectares, string? Localisation);