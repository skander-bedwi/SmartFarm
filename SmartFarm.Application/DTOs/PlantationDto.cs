namespace SmartFarm.Application.DTOs;

public record PlantationDto(Guid Id, DateTime DatePlantation, DateTime? DateRecoltePrevue, string? Statut, Guid CultureId);

public record CreatePlantationDto(DateTime DatePlantation, DateTime? DateRecoltePrevue, string? Statut, Guid CultureId);