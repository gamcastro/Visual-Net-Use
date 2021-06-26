using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SESUM.VisualNetUse.UI.Utils;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace SESUM.VisualNetUse.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {            
            RaisePropertyChanged("IsPastaMontada");
            MontarCommand = new RelayCommand(MontarCommandMethod, CanMontarCommandMethod);
        }

        public RelayCommand MontarCommand { get; private set; }

        public bool IsPastaMontada
        {
            get
            {
                return Executor.GetPastaMontada();
            }
        }
        public void MontarCommandMethod()
        {
              
            Executor.MontarAmbiente(@"C:\app\", "montapastascorporativas.ps1");          
            Executor.ExecutaPowerShellScript(@"C:\app\", "montapastascorporativas.ps1");
            RaisePropertyChanged("IsPastaMontada");
            MontarCommand.RaiseCanExecuteChanged();
            
        }

        public bool CanMontarCommandMethod()
        {
            return !IsPastaMontada;
        }
    }
}