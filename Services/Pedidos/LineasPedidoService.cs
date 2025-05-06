using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public async Task EliminarLineaPedido(int idLineaPedido)
        {
            try
            {
                // Buscar la línea de pedido en la base de datos
                var lineaPedido = _context.Lineas_Pedido.FirstOrDefault(lp => lp.ID == idLineaPedido);

                if (lineaPedido != null)
                {
                    _context.Lineas_Pedido.Remove(lineaPedido);
                    await _context.SaveChangesAsync();
                    // MessageBox.Show($"Línea de pedido {idLineaPedido} eliminada correctamente.", "Éxito");
                }
                else
                {
                    MessageBox.Show($"No se encontró la línea de pedido con ID {idLineaPedido}.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la línea de pedido de la base de datos.", "Error");
            }
        }

    }

}
