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
using System.Windows.Shapes;
using TPVproyecto.ViewModels.VentanasVM;

namespace TPVproyecto.Views.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PagarWindow.xaml
    /// </summary>
    public partial class PagarWindow : Window
    {
        PagarVM _pagarVM;

        public PagarWindow(decimal total)
        {
            InitializeComponent();
            _pagarVM = new PagarVM(total);
            this.DataContext = _pagarVM;
        }
    }
}
