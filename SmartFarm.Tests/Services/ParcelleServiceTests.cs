using FluentAssertions;
using Moq;
using SmartFarm.Application.DTOs;
using SmartFarm.Application.Interfaces;
using SmartFarm.Application.Services;
using SmartFarm.Domain.Entities;
using SmartFarm.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SmartFarm.Tests.Services
{
    public class ParcelleServiceTests
    {
        private readonly Mock<IGenericRepository<Parcelle>> _repositoryMock;
        private readonly ParcelleService _service;

        public ParcelleServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<Parcelle>>();
            _service = new ParcelleService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_AvecDonneesValides_DoitCreerLaParcelle()
        {
            // Arrange
            var dto = new CreateParcelleDto("Parcelle Nord", 3.5, "Nabeul");

            // Act
            var id = await _service.CreateAsync(dto);

            // Assert
            id.Should().NotBeEmpty();
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Parcelle>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_AvecSurfaceNegative_DoitLeverUneException()
        {
            // Arrange
            var dto = new CreateParcelleDto("Parcelle Test", -5, "Nabeul");

            // Act
            Func<Task> act = async () => await _service.CreateAsync(dto);

            // Assert
            await act.Should().ThrowAsync<BusinessRuleException>()
                .WithMessage("*superieure a 0*");
        }

        [Fact]
        public async Task CreateAsync_AvecNomVide_DoitLeverUneException()
        {
            // Arrange
            var dto = new CreateParcelleDto("", 3.5, "Nabeul");

            // Act
            Func<Task> act = async () => await _service.CreateAsync(dto);

            // Assert
            await act.Should().ThrowAsync<BusinessRuleException>();
        }

        [Fact]
        public async Task GetAllAsync_DoitRetournerLaListeDesParcelles()
        {
            // Arrange
            var parcelles = new List<Parcelle>
            {
                new Parcelle { Id = Guid.NewGuid(), Nom = "Parcelle A", SurfaceHectares = 2, Localisation = "Sousse" },
                new Parcelle { Id = Guid.NewGuid(), Nom = "Parcelle B", SurfaceHectares = 4, Localisation = "Sfax" }
            };
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(parcelles);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
        }
    }
}