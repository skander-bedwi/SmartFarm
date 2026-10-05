namespace SmartFarm.Domain.Entities;

public class Culture
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nom { get; set; } = string.Empty;
    public string? Variete { get; set; }

    public Guid ParcelleId { get; set; }
    public Parcelle? Parcelle { get; set; }

    public ICollection<Plantation> Plantations { get; set; } = new List<Plantation>();
}