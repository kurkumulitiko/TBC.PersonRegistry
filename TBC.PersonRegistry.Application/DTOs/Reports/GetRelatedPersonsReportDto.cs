using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs.Reports;

public class GetRelatedPersonsReportDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PrivateNumber { get; set; }
    public PersonRelationType RelationType { get; set; }
    public int RelatedPeopleAmount { get; set; }
}
