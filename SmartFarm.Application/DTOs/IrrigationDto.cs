namespace SmartFarm.Application.DTOs;

public record IrrigationDto(Guid Id, DateTime DateIrrigation, double VolumeEauLitres, string? Methode, Guid ParcelleId);

public record CreateIrrigationDto(double VolumeEauLitres, string? Methode, Guid ParcelleId);