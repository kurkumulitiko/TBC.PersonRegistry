using Microsoft.EntityFrameworkCore;
using TBC.PersonRegistry.Application.Commons;
using TBC.PersonRegistry.Application.DTOs.Filters;
using TBC.PersonRegistry.Application.DTOs.Reports;
using TBC.PersonRegistry.Application.Interfaces.Repositories;
using TBC.PersonRegistry.Domain.Models;
using TBC.PersonRegistry.Persistence.Extensions;

namespace TBC.PersonRegistry.Persistence.Implementations.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(DataContext context) : base(context) { }

    private IQueryable<Person> Including =>
       this.context.People
           .Include(x => x.Phones)
           .Include(x => x.City)
           .Include(x => x.RelatedPeople)
               .ThenInclude(x => x.RelatedPerson)
               .ThenInclude(x => x.Phones);

    public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await this.Including.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public Task AddRelatedPerson(PersonRelation personRelation)
    {
        context.PersonRelations.Add(personRelation);
        return Task.CompletedTask;
    }

    public async Task<PersonRelation> GetRelationByPersonAndRelatedPersonIdAsync(int personId, int relatedPersonId, CancellationToken cancellationToken = default)
    {

        return await context.PersonRelations.FirstOrDefaultAsync(x => (x.PersonId == personId && x.RelatedPersonId == relatedPersonId) || (x.PersonId == relatedPersonId && x.RelatedPersonId == personId && x.DeletedAt == null), cancellationToken);

    }

    public Task DeleteRelation(PersonRelation relation)
    {
        context.PersonRelations.Update(relation);
        return Task.CompletedTask;
    }

    public async Task<Pagination<Person>> FilterAsync(int pageIndex, int pageSize, string searchQuery, PersonFilter? personFilter = null, CancellationToken cancellationToken = default)
    {
        return await this.Including
              .ApplyQuickSearch(searchQuery)
              .ApplyFilterParameters(personFilter)
             .OrderByDescending(x => x.CreatedAt)
            .ToPaginatedAsync(pageIndex, pageSize, cancellationToken);

    }


    public async Task<IEnumerable<GetRelatedPersonsReportDto>> GetPersonRelationReport(CancellationToken cancellationToken = default)
    {
      return await (from p in context.People
         join r in context.PersonRelations on p.Id equals r.PersonId
         where p.DeletedAt == null && r.DeletedAt == null
        group r by new { p.Id, p.FirstName, p.LastName, p.PrivateNumber, r.RelationType}
          into gr
         select new GetRelatedPersonsReportDto
         {
             Id = gr.Key.Id,
             FirstName = gr.Key.FirstName,
             LastName = gr.Key.LastName,
             PrivateNumber = gr.Key.PrivateNumber,
             RelationType = gr.Key.RelationType,
             RelatedPeopleAmount = gr.Count()
         }).ToListAsync(cancellationToken);

    }

}

