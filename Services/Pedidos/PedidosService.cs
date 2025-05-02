using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TPVproyecto.Database;
using TPVproyecto.Models;
using TPVproyecto.Models.Pedido;

namespace TPVproyecto.Services.Pedidos
{
    public class PedidosService
    {
        private readonly DBContexto _context;

        // Constructor
        public PedidosService()
        {
            _context = new DBContexto();
        }

        // Obtener todos los pedidos de la base de datos
        public List<Pedido> ObtenerPedidos()
        {
            var pedidos = _context.Pedido
                .Include(p => p.Mesa) // Cargar información de la mesa vinculada
                .ToList();

            return pedidos;
        }

        // Obtener detalles de una mesa por su ID
        public Mesa ObtenerMesa(int idMesa)
        {
            return _context.Mesas.FirstOrDefault(m => m.Id == idMesa);
        }


        // Completar pedido
        public void CompletarPedido(int idMesa)
        {
            try
            {
                // Obtener todos los pedidos de la mesa
                var pedidosMesa = _context.Pedido.Where(p => p.IdMesa == idMesa).ToList();

                if (pedidosMesa.Any())
                {
                    // Actualizar el estado de los pedidos
                    foreach (var pedido in pedidosMesa)
                    {
                        pedido.IsPagado = true;
                    }

                    // Guardar cambios en la base de datos
                    _context.Pedido.UpdateRange(pedidosMesa);
                    _context.SaveChanges();

                    // MessageBox.Show($"Se han actualizado {pedidosMesa.Count} pedidos de la mesa {idMesa}.", "Éxito");
                }
                else
                {
                    MessageBox.Show($"No se encontraron pedidos para la mesa {idMesa}.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los pedidos de la mesa.", "Error");
            }
        }
    }
}
