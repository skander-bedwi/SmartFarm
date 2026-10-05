using Microsoft.EntityFrameworkCore;
using SmartFarm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFarm.Infrastructure.Persistence
{
    public class SmartFarmDbContext : DbContext
    {
        public SmartFarmDbContext(DbContextOptions<SmartFarmDbContext> options) : base(options) { }

        public DbSet<Parcelle> Parcelles => Set<Parcelle>();
        public DbSet<Culture> Cultures => Set<Culture>();
        public DbSet<Plantation> Plantations => Set<Plantation>();
        public DbSet<MesureCapteur> Mesures => Set<MesureCapteur>();
        public DbSet<Irrigation> Irrigations => Set<Irrigation>();
        public DbSet<Intervention> Interventions => Set<Intervention>();
    }
}
