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
    public class InterventionServiceTests
    {
        private readonly Mock<IGenericRepository<Intervention>> _repositoryMock;
        private readonly InterventionService _service;

        public InterventionServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<Intervention>>();
            _service = new InterventionService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_AvecTypeValide_DoitCreerLIntervention()
        {
            var dto = new CreateInterventionDto("Fertilisation", "Apport azote", Guid.NewGuid());

            var id = await _service.CreateAsync(dto);

            id.Should().NotBeEmpty();
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Intervention>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_AvecTypeVide_DoitLeverUneException()
        {
            var dto = new CreateInterventionDto("", "Apport azote", Guid.NewGuid());

            Func<Task> act = async () => await _service.CreateAsync(dto);

            await act.Should().ThrowAsync<BusinessRuleException>();
        }
    }
}