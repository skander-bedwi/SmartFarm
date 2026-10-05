namespace SmartFarm.Domain.Entities;

public class MesureCapteur
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Temperature { get; set; }
    public double Humidite { get; set; }
    public DateTime DateMesure { get; set; } = DateTime.UtcNow;

    public Guid ParcelleId { get; set; }
    public Parcelle? Parcelle { get; set; }
}