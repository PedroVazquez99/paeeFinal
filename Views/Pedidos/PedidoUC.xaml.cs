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

namespace TPVproyecto.Views.Pedidos
{
    /// <summary>
    /// Lógica de interacción para PedidoUC.xaml
    /// </summary>
    public partial class PedidoUC : UserControl
    {
        //private PedidoVM _pedidoVM;
        public PedidoUC()
        {
            InitializeComponent();

            //_pedidoVM = new PedidoVM();
            //DataContext = _pedidoVM;
        }
    }
}
