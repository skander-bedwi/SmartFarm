namespace SmartFarm.Domain.Entities;

public class Plantation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DatePlantation { get; set; }
    public DateTime? DateRecoltePrevue { get; set; }
    public string? Statut { get; set; }

    public Guid CultureId { get; set; }
    public Culture? Culture { get; set; }
}