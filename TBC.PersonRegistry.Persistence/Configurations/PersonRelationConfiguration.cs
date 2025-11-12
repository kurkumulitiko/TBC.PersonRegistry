using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence.Configurations
{
    internal class PersonRelationConfiguration : IEntityTypeConfiguration<PersonRelation>
    {
        public void Configure(EntityTypeBuilder<PersonRelation> builder)
        {
            builder.ToTable("PersonRelations");

            builder.HasKey(p => p.Id);

            builder .Property(x => x.PersonId).IsRequired();
            builder.Property(x => x.RelatedPersonId).IsRequired();


            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.RelatedPeople)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(x => x.RelatedPerson)
                .WithMany()
                .HasForeignKey(x => x.RelatedPersonId)
                .OnDelete(DeleteBehavior.NoAction);
        
        }
    }
}
