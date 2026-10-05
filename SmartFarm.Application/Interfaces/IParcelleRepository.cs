using SmartFarm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFarm.Application.Interfaces
{
    public interface IParcelleRepository
    {
        Task<Parcelle?> GetByIdAsync(Guid id);
        Task<IEnumerable<Parcelle>> GetAllAsync();
        Task AddAsync(Parcelle parcelle);
    }
}
