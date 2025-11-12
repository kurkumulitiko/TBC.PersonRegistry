using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs
{
    public class PhoneDTO
    {
        public string PhoneNumber { get; set; }
        public PhoneNumberType NumberType { get; set; }
    }
}
