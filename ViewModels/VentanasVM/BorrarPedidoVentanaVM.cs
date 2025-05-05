using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Services.Pedidos;
using TPVproyecto.ViewModels.Admin.AdminModalVM;

namespace TPVproyecto.ViewModels.VentanasVM
{
    public class BorrarPedidoVentanaVM : BaseVM
    {
        PedidosService _pedidosService;

        // Comandos para borrar y cancelar
        public ICommand AceptarBorrarCommand { get; }
        public ICommand CancelarCommand { get; }

        // Evento para cerrar la ventana
        public event Action CloseWindowRequested;

        // Constructor
        public BorrarPedidoVentanaVM(int pedidoId)
        {
            _pedidosService = new PedidosService();

            AceptarBorrarCommand = new RelayCommand(_ => BorrarPedido(pedidoId));
            CancelarCommand = new RelayCommand(Cancelar);

        }

        private void BorrarPedido(int pedidoId)
        {
            // Lógica para eliminar el pedido de la base de datos
            _pedidosService.EliminarPedido(pedidoId);

            // Cierra la ventana después de borrar
            CloseWindowRequested?.Invoke();
        }

        private void Cancelar(object parameter)
        {
            // Cierra la ventana sin eliminar el pedido
            Console.WriteLine("Eliminación cancelada.");
            CloseWindowRequested?.Invoke();
        }
    }
}
