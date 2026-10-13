using FluentAssertions;
using Moq;
using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Application.Services;
using SmartFarm.Domain.Entities;
using SmartFarm.Domain.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SmartFarm.Tests.Services
{
    public class MesureCapteurServiceTests
    {
        private readonly Mock<IGenericRepository<MesureCapteur>> _repositoryMock;
        private readonly MesureCapteurService _service;

        public MesureCapteurServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<MesureCapteur>>();
            _service = new MesureCapteurService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_AvecDonneesValides_DoitCreerLaMesure()
        {
            var dto = new CreateMesureCapteurDto(27.5, 62.0, Guid.NewGuid());

            var id = await _service.CreateAsync(dto);

            id.Should().NotBeEmpty();
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<MesureCapteur>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_AvecHumiditeHorsLimites_DoitLeverUneException()
        {
            var dto = new CreateMesureCapteurDto(27.5, 150, Guid.NewGuid()); // 150% invalide

            Func<Task> act = async () => await _service.CreateAsync(dto);

            await act.Should().ThrowAsync<BusinessRuleException>();
        }
    }
}