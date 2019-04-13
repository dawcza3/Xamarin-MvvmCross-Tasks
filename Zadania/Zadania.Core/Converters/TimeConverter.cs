using MvvmCross.Platform.Converters;
using System;
using System.Globalization;

namespace Zadania.Core.Converters
{
    public class TimeConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var time = (TimeSpan)value;
                return new DateTime(2018, 1, 1, time.Hours, time.Minutes, time.Seconds);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                DateTime date = (DateTime)value;
                return new TimeSpan(date.Hour, date.Minute, date.Second);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.MinValue;
            }
        }
    }
}
