using MediatR;
using TBC.PersonRegistry.Application.DTOs.Reports;
using TBC.PersonRegistry.Application.Interfaces;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetRelatedPersonsReport;

public class GetRelatedPersonsReportQueryHandler : IRequestHandler<GetRelatedPersonsReportQuery, IEnumerable<GetRelatedPersonsReportDto>>
{
    private readonly IUnitOfWork _uow;

    public GetRelatedPersonsReportQueryHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }


    public async Task<IEnumerable<GetRelatedPersonsReportDto>> Handle(GetRelatedPersonsReportQuery request, CancellationToken cancellationToken)
    {
        return await _uow.PersonRepository.GetPersonRelationReport(cancellationToken);
    }
}
