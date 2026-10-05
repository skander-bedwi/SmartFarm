namespace SmartFarm.Domain.Entities;

public class Parcelle
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nom { get; set; } = string.Empty;
    public double SurfaceHectares { get; set; }
    public string? Localisation { get; set; }
    public DateTime DateCreation { get; set; } = DateTime.UtcNow;

    public ICollection<Culture> Cultures { get; set; } = new List<Culture>();
    public ICollection<MesureCapteur> Mesures { get; set; } = new List<MesureCapteur>();
    public ICollection<Irrigation> Irrigations { get; set; } = new List<Irrigation>();
    public ICollection<Intervention> Interventions { get; set; } = new List<Intervention>();
}