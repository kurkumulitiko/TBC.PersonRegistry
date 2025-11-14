using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs
{
    public class PhoneDTO
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public PhoneNumberType NumberType { get; set; }
    }
}
