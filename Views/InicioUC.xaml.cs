using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPVproyecto.Services;
using TPVproyecto.ViewModels;

namespace TPVproyecto.Views
{
    /// <summary>
    /// Lógica de interacción para InicioUC.xaml
    /// </summary>
    public partial class InicioUC : UserControl
    {
        //private InicioVM _mainVM;
        //private NavigationStore _navigationStore;

        public InicioUC()
        {
            InitializeComponent();
            //_navigationStore = new NavigationStore();
            //_mainVM = new InicioVM();
            //this.DataContext = _mainVM;
        }
    }
}
