using SESUM.VisualNetUse.UI.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SESUM.VisualNetUse.UI
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool isVpnConectada = Executor.CheckForVPNInterface();
            MainWindow main = new MainWindow();
            if (!isVpnConectada)
            {
                MessageBox.Show("Realize o procedimento de conexão com a VPN.\nApós abra novamente esta aplicação","VPN Desconectada",MessageBoxButton.OK,MessageBoxImage.Warning); ;
                Application.Current.Shutdown();
            }
            else
            {
                main.Show();
            }
        }
    }
}
