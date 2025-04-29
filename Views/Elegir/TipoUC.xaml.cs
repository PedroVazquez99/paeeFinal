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
using TPVproyecto.ViewModels;

namespace TPVproyecto.Views.Elegir
{
    /// <summary>
    /// Lógica de interacción para UCElegir.xaml
    /// </summary>
    public partial class TipoUC : UserControl
    {
        // private ElegirTipoVM _elegirVM;

        public TipoUC()
        {
            InitializeComponent();

            // _elegirVM = new ElegirTipoVM();
            // this.DataContext = _elegirVM; // asociamos vista con su ViewModel

        }
    }
}
