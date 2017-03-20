using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Intermoda.Maquilado.Converter
{
    public class OrdenEstadoToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var estado = (string) value;

            switch (estado)
            {
                case "En Espera":
                    return new SolidColorBrush(Colors.Moccasin);
                case "En Proceso":
                    return new SolidColorBrush(Colors.LightGreen);
                case "En Espera de enviar":
                    return new SolidColorBrush(Colors.LightBlue);
                case "Procesando":
                    return new SolidColorBrush(Colors.Salmon);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}