namespace SmartFarm.Application.DTOs;

public record InterventionDto(Guid Id, string Type, string? Description, DateTime DateIntervention, Guid ParcelleId);

public record CreateInterventionDto(string Type, string? Description, Guid ParcelleId);