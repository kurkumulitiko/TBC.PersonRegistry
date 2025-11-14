using TBC.PersonRegistry.Domain.Basics;

namespace TBC.PersonRegistry.Domain.Models;

public class City : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Person> People { get; set; }

    public City()
    {
        People = new HashSet<Person>();
    }
}

