using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence.Configurations.Seeds;

internal static class CitySeed
{
    internal static readonly City Tbilisi = new City { Id = 1, Name = "Tbilisi" };
    internal static readonly City Mtsketa = new City { Id = 2, Name = "Mtsketa" };
    internal static readonly City Kutaisi = new City { Id = 3, Name = "Kutaisi" };

}

