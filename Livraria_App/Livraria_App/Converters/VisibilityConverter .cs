using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Livraria_App.Converters
{

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string nivelAcesso)
            {
                return nivelAcesso != "user";
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
