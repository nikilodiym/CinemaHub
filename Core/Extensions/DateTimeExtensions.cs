namespace Core.Extensions;

public static class DateTimeExtensions
{
    public static bool IsWeekend(this DateTime dateTime)
    {
        return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
    }

    public static string ToReadableString(this DateTime dateTime)
    {
        return dateTime.ToString("MMMM dd, yyyy");
    }
    
    public static int DaysUntil(this DateTime dateTime, DateTime futureDate)
    {
        return (futureDate - dateTime).Days;
    }
}