using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TPVproyecto.Models;
using TPVproyecto.ViewModels.VentanasVM;

namespace TPVproyecto.Views.Ventanas
{
    /// <summary>
    /// Lógica de interacción para MesaWindow.xaml
    /// </summary>
    public partial class MesaWindow : Window
    {
        private MesaVentanaVM _pagarVentanaVM;
        public MesaWindow(ObservableCollection<Helado> helados)
        {
            InitializeComponent();
            _pagarVentanaVM = new MesaVentanaVM(helados);
            this.DataContext = _pagarVentanaVM;
        }
    }
}
