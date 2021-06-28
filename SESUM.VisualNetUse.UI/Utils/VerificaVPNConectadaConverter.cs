using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SESUM.VisualNetUse.UI.Utils
{
    public class VerificaVPNConectada : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVPNConectada = (bool)value;
            if (isVPNConectada)
            {
                return "A conexão VPN está conectada";
            }
            else
            {
                return "A conexão VPN está desconectada";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
