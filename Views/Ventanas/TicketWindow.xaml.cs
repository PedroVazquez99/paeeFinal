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
using TPVproyecto.Models.Pedido;
using TPVproyecto.ViewModels.VentanasVM;

namespace TPVproyecto.Views.Ventanas
{
    /// <summary>
    /// Lógica de interacción para TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        TicketWindowVM _ticketWindowVM;
        public TicketWindow(Pedido _pedido)
        {
            InitializeComponent();
            _ticketWindowVM = new TicketWindowVM(_pedido);
            this.DataContext = _ticketWindowVM;
        }
    }
}
