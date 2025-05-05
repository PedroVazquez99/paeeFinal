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
    /// Lógica de interacción para BorrarPedidoWindow.xaml
    /// </summary>
    public partial class BorrarPedidoWindow : Window
    {
        BorrarPedidoVentanaVM _borrarVentanaVM;

        public BorrarPedidoWindow(int idPedido)
        {
            InitializeComponent();
            _borrarVentanaVM = new BorrarPedidoVentanaVM(idPedido);
            this.DataContext = _borrarVentanaVM;

            _borrarVentanaVM.CloseWindowRequested += () => this.Close();

        }
    }
}
