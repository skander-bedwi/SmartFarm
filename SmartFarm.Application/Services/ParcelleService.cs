using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFarm.Application.Services
{
    public  class ParcelleService
    {
        private readonly IParcelleRepository _repository;

        public ParcelleService(IParcelleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ParcelleDto>> GetAllAsync()
        {
            var parcelles = await _repository.GetAllAsync();
            return parcelles.Select(p => new ParcelleDto(p.Id, p.Nom, p.SurfaceHectares, p.Localisation));
        }

        public async Task<Guid> CreateAsync(CreateParcelleDto dto)
        {
            var parcelle = new Parcelle
            {
                Id = Guid.NewGuid(),
                Nom = dto.Nom,
                SurfaceHectares = dto.SurfaceHectares,
                Localisation = dto.Localisation
            };

            await _repository.AddAsync(parcelle);
            return parcelle.Id;
        }
    }
}
