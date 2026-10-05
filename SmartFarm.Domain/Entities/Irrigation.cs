namespace SmartFarm.Domain.Entities;

public class Irrigation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateIrrigation { get; set; } = DateTime.UtcNow;
    public double VolumeEauLitres { get; set; }
    public string? Methode { get; set; }

    public Guid ParcelleId { get; set; }
    public Parcelle? Parcelle { get; set; }
}