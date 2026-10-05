namespace SmartFarm.Application.DTOs;

public record MesureCapteurDto(Guid Id, double Temperature, double Humidite, DateTime DateMesure, Guid ParcelleId);

public record CreateMesureCapteurDto(double Temperature, double Humidite, Guid ParcelleId);