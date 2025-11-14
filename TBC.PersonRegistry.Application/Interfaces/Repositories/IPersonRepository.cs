using TBC.PersonRegistry.Application.Commons;
using TBC.PersonRegistry.Application.DTOs.Filters;
using TBC.PersonRegistry.Application.DTOs.Reports;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Application.Interfaces.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person?> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddRelatedPerson(PersonRelation personRelation);
    Task<PersonRelation?> GetRelationByPersonAndRelatedPersonIdAsync(int personId, int relatedPersonId, CancellationToken cancellationToken = default);
    Task DeleteRelation(PersonRelation relation);
    Task<Pagination<Person>> FilterAsync(int pageIndex, int pageSize, string searchQuery, PersonFilter? personFilter = null, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRelatedPersonsReportDto>> GetPersonRelationReport(CancellationToken cancellationToken);
}

