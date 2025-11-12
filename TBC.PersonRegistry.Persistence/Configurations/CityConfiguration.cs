using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.PersonRegistry.Domain.Models;
using TBC.PersonRegistry.Persistence.Configurations.Seeds;

namespace TBC.PersonRegistry.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

        builder.HasData(CitySeed.Tbilisi,
                        CitySeed.Mtsketa, 
                        CitySeed.Kutaisi);
    }
}

