using FluentAssertions;
using Moq;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Features.People.Queries.GetPersonDetails;
using TBC.PersonRegistry.Application.Interfaces;
using TBC.PersonRegistry.Application.Interfaces.Repositories;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Tests.Unit.Application.Features.People.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IPersonRepository> _personRepoMock;
        private readonly GetPersonDetailsQueryHandler _handler;

        public GetPersonDetailsQueryHandlerTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _personRepoMock = new Mock<IPersonRepository>();

            _uowMock.Setup(x => x.PersonRepository)
                    .Returns(_personRepoMock.Object);

            _handler = new GetPersonDetailsQueryHandler(_uowMock.Object);
        }

        // TEST 1: Person not found
        [Fact]
        public async Task Handle_WhenPersonDoesNotExist_ShouldThrow_NotFoundException()
        {
            // Arrange
            var query = new GetPersonDetailsQuery { Id = 99 };

            _personRepoMock
                .Setup(r => r.GetPersonByIdAsync(query.Id, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Person)null);

            // Act
            var act = async () => await _handler.Handle(query, CancellationToken.None);

            // Assert
            await act.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("*99*");
        }

        // TEST 2: Person found
        [Fact]
        public async Task Handle_WhenPersonExists_ShouldReturn_PersonDto()
        {
            // Arrange
            var fakePerson = new Person
            {
                Id = 1,
                FirstName = "Tinatin",
                LastName = "Kurkumuli",
                Gender = Domain.Enums.Gender.Female,
                PrivateNumber = "11111111111"
            };

            _personRepoMock
                .Setup(r => r.GetPersonByIdAsync(1, It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakePerson);

            var query = new GetPersonDetailsQuery { Id = 1 };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetPersonDTO
            {
                Id = 1,
                FirstName = "Tinatin",
                LastName = "Kurkumuli",
                Gender = Domain.Enums.Gender.Female,
                PrivateNumber = "11111111111"
            });

            _personRepoMock.Verify(
                x => x.GetPersonByIdAsync(1, It.IsAny<CancellationToken>()),
                Times.Once);
        }

    }
}
