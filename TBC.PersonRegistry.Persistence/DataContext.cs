using Microsoft.EntityFrameworkCore;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Person> People { get; private set; }
    public DbSet<City> Cities { get; private set; }
    public DbSet<PersonRelation> PersonRelations { get; private set; }
    public DbSet<Phone> Phones { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}

