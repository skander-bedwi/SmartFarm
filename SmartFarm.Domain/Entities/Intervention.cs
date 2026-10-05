namespace SmartFarm.Domain.Entities;

public class Intervention
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DateIntervention { get; set; } = DateTime.UtcNow;

    public Guid ParcelleId { get; set; }
    public Parcelle? Parcelle { get; set; }
}