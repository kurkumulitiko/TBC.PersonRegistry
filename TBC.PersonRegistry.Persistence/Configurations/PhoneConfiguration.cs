using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence.Configurations;

internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("Phones");

        builder.HasKey(p => p.Id);

        builder.Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired();
        builder.Property(x => x.NumberType).IsRequired();
        builder.Property(x => x.PersonId).IsRequired();
    }

}

