using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Kairos
{
    public class LongToDateTimeConverter : IValueConverter
    {
        DateTime _time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long dateTime = (long)value;
            return $"{_time.AddSeconds(dateTime)} GMT+2";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
