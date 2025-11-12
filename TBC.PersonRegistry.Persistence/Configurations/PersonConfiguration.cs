using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.PersonRegistry.Domain.Models;
using TBC.PersonRegistry.Persistence.Configurations.Seeds;

namespace TBC.PersonRegistry.Persistence.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PrivateNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("date").IsRequired();
            builder.Property(x => x.Gender).IsRequired();

            builder.HasIndex(x => x.PrivateNumber).IsUnique();

            builder.HasOne(x => x.City).WithMany(c => c.People).HasForeignKey(x => x.CityId);


            builder.HasData(PersonSeed.AnaAbashidze,
                            PersonSeed.GiorgiGiorgidze);

        }
    }
}
