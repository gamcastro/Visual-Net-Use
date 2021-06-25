using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SESUM.VisualNetUse.UI.Utils
{
    public class VerificaPastaMontadaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPastaMontada = (bool)value;
            if (isPastaMontada)
            {
                return "As pastas corporativas já estão montadas";
            }
            else
            {
                return "As pastas corporativas não estão montadas";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
