namespace TBC.PersonRegistry.Application.Commons.Extensions;

public static class DateTimeExtension
{
    public static bool PersonAgeCheck(this DateTime birthDate)
    {
        return birthDate.Date.AddYears(18) <= DateTime.Today;
    }
}

