using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Services.Pedidos;
using TPVproyecto.Views.Ventanas;

namespace TPVproyecto.Commands
{
    public class BorrarPedidoCommand : CommandBase
    {
        int _idPedido;
        PedidosService _pedidosService;
        // Constructor
        public BorrarPedidoCommand(int idPedido) {
            _idPedido = idPedido;
            _pedidosService = new PedidosService();
        }

        // Execute
        public override void Execute(object? parameter)
        {
            Console.WriteLine(_idPedido.ToString());
            var x = new BorrarPedidoWindow(_idPedido);
            x.Show();
        }
    }
}
