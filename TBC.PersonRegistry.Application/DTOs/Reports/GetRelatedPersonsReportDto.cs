using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs.Reports;

public class GetRelatedPersonsReportDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PrivateNumber { get; set; } = string.Empty;
    public PersonRelationType RelationType { get; set; }
    public int RelatedPeopleAmount { get; set; }
}
