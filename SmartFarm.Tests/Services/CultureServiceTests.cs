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
    public class CultureServiceTests
    {
        private readonly Mock<IGenericRepository<Culture>> _repositoryMock;
        private readonly CultureService _service;

        public CultureServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<Culture>>();
            _service = new CultureService(_repositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_AvecDonneesValides_DoitCreerLaCulture()
        {
            var dto = new CreateCultureDto("Tomate", "Roma", Guid.NewGuid());

            var id = await _service.CreateAsync(dto);

            id.Should().NotBeEmpty();
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Culture>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_AvecNomVide_DoitLeverUneException()
        {
            var dto = new CreateCultureDto("", "Roma", Guid.NewGuid());

            Func<Task> act = async () => await _service.CreateAsync(dto);

            await act.Should().ThrowAsync<BusinessRuleException>();
        }
    }
}