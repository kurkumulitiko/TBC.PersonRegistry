using TBC.PersonRegistry.Application.DTOs.Filters;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Persistence.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<Person> ApplyQuickSearch(this IQueryable<Person> source, string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return source;

        var search = query.Trim().ToLower();

        return source.Where(p =>
            p.FirstName.ToLower().Contains(search) ||
            p.LastName.ToLower().Contains(search) ||
            p.PrivateNumber.Contains(search));
    }

    public static IQueryable<Person> ApplyFilterParameters(this IQueryable<Person> source, PersonFilter personFilter)
    {
        if (personFilter == null)
            return source;

        if (!string.IsNullOrEmpty(personFilter.FirstName?.Trim()))
            source = source.Where(x => x.FirstName.StartsWith(personFilter.FirstName));

        if (!string.IsNullOrEmpty(personFilter.LastName?.Trim()))
            source = source.Where(x => x.LastName.StartsWith(personFilter.LastName));

        if (!string.IsNullOrEmpty(personFilter.PrivateNumber?.Trim()))
            source = source.Where(x => x.PrivateNumber.StartsWith(personFilter.PrivateNumber));

        if (personFilter.BirthDate.HasValue)
            source = source.Where(x => x.BirthDate.Date == personFilter.BirthDate.Value.Date);

        if (personFilter.CityId > 0)
            source = source.Where(x => x.CityId == personFilter.CityId);

        if (personFilter.Gender.HasValue)
            source = source.Where(p => p.Gender == personFilter.Gender.Value);

        if (personFilter.BirthDate.HasValue)
            source = source.Where(p => p.BirthDate.Date == personFilter.BirthDate.Value.Date);


        return source;
    }
}
