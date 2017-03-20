using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Intermoda.Maquilado.Wip
{
    public class TimeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan) value;

            if (time < new TimeSpan(18, 0, 0, 0))
            {
                return new SolidColorBrush(Colors.LightGreen);
            }

            if (time >= new TimeSpan(18, 0, 0, 0) && time < new TimeSpan(21, 0, 0, 0))
            {
                return new SolidColorBrush(Colors.Yellow);
            }

            return new SolidColorBrush(Colors.Salmon);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}