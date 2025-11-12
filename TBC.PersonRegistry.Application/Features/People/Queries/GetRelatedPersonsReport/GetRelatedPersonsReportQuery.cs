using MediatR;
using TBC.PersonRegistry.Application.DTOs.Reports;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetRelatedPersonsReport;

public class GetRelatedPersonsReportQuery : IRequest<IEnumerable<GetRelatedPersonsReportDto>>
{
}
