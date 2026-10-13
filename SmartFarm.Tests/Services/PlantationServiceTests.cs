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
    public class PlantationServiceTests
    {
        private readonly Mock<IGenericRepository<Plantation>> _repositoryMock;
        private readonly PlantationService _service;

        public PlantationServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<Plantation>>();
            _service = new PlantationService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_AvecDatesValides_DoitCreerLaPlantation()
        {
            var dto = new CreatePlantationDto(
                DateTime.UtcNow,
                DateTime.UtcNow.AddMonths(3),
                "En cours",
                Guid.NewGuid());

            var id = await _service.CreateAsync(dto);

            id.Should().NotBeEmpty();
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Plantation>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_AvecDateRecolteAvantPlantation_DoitLeverUneException()
        {
            var datePlantation = DateTime.UtcNow;
            var dto = new CreatePlantationDto(
                datePlantation,
                datePlantation.AddDays(-1), // récolte AVANT plantation = invalide
                "En cours",
                Guid.NewGuid());

            Func<Task> act = async () => await _service.CreateAsync(dto);

            await act.Should().ThrowAsync<BusinessRuleException>();
        }
    }
}