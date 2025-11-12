using TBC.PersonRegistry.Domain.Enums;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence.Configurations.Seeds;

internal static class PersonSeed
{
    internal static readonly Person AnaAbashidze = new Person
    {
        Id = 1,
        FirstName = "Ana",
        LastName = "Abashidze",
        PrivateNumber = "00000000000",
        BirthDate = new DateTime(2000, 5, 15),
        Gender = Gender.Female,
        CityId = CitySeed.Mtsketa.Id,
        CreatedAt = new DateTime(2024, 1, 1)
    };

    internal static readonly Person GiorgiGiorgidze = new Person
    {
        Id = 2,
        FirstName = "Giorgi",
        LastName = "Giorgidze",
        PrivateNumber = "11111111111",
        BirthDate = new DateTime(2008, 7, 20),
        Gender = Gender.Male,
        CityId = CitySeed.Tbilisi.Id,
        CreatedAt = new DateTime(2024, 1, 1)
    };
}

