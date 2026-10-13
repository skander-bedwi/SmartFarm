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
    public class IrrigationServiceTests
    {
        private readonly Mock<IGenericRepository<Irrigation>> _repositoryMock;
        private readonly IrrigationService _service;

        public IrrigationServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<Irrigation>>();
            _service = new IrrigationService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_AvecVolumeValide_DoitCreerLIrrigation()
        {
            var dto = new CreateIrrigationDto(150, "Goutte a goutte", Guid.NewGuid());

            var id = await _service.CreateAsync(dto);

            id.Should().NotBeEmpty();
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Irrigation>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_AvecVolumeNegatif_DoitLeverUneException()
        {
            var dto = new CreateIrrigationDto(-10, "Goutte a goutte", Guid.NewGuid());

            Func<Task> act = async () => await _service.CreateAsync(dto);

            await act.Should().ThrowAsync<BusinessRuleException>();
        }
    }
}