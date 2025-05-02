using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Database;
using TPVproyecto.Models.Pedido;

namespace TPVproyecto.Services.Pedidos
{
    public class LineasPedidoService
    {
        private readonly DBContexto _context;

        public LineasPedidoService()
        {
            _context = new DBContexto();
        }

        public List<LineaPedido> ObtenerLineasPedidoPorPedido(int idPedido)
        {
            return _context.Lineas_Pedido
                .Include(lp => lp.Tipo) // Cargar información de Tipo
                .Include(lp => lp.Topping) // Cargar información de Topping
                .Include(lp => lp.Sabor)   // Cargar información de Sabor
                .Include(lp => lp.Tamanyo) // Cargar información de Tamanyo
                .Where(lp => lp.ID_Pedido == idPedido)
                .ToList();
        }
    }

}
