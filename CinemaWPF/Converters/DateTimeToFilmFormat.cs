using System;
using System.Globalization;
using System.Windows.Data;

namespace CinemaWPF.Converters;

public class DateTimeToFilmFormat : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
        {
            return dateTime.ToString("dd MMM yyyy", culture);
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string dateString && DateTime.TryParseExact(dateString, "dd MMM yyyy", culture, DateTimeStyles.None, out var dateTime))
        {
            return dateTime;
        }

        return DateTime.MinValue;
    }
}