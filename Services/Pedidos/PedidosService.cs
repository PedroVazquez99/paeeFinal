﻿using Microsoft.EntityFrameworkCore;
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
            return _context.Mesa.FirstOrDefault(m => m.Id == idMesa);
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

                    // 🔄 Actualizar el estado de la mesa
                    var mesa = _context.Mesa.FirstOrDefault(m => m.Id == idMesa);
                    if (mesa != null)
                    {
                        mesa.IsActivo = false; // Desactivar la mesa
                        _context.Mesa.Update(mesa); // Guardar cambios en la mesa
                    }


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


        // Eliminar un pedido de la base de datos por su ID
        public async Task EliminarPedido(int idPedido)
        {
            try
            {
                var lineasPedido = _context.Lineas_Pedido.Where(lp => lp.ID_Pedido == idPedido);

                _context.Lineas_Pedido.RemoveRange(lineasPedido); // Elimina las líneas asociadas
                await _context.SaveChangesAsync(); // Guarda cambios antes de eliminar el pedido

                // Buscar el pedido en la base de datos
                var pedido = _context.Pedido.FirstOrDefault(p => p.ID_Pedido == idPedido);

                if (pedido != null)
                {
                    _context.Pedido.Remove(pedido);
                    await _context.SaveChangesAsync();
                    // MessageBox.Show($"Pedido {idPedido} eliminado correctamente.", "Éxito");
                }
                else
                {
                    MessageBox.Show($"No se encontró el pedido con ID {idPedido}.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pedido de la base de datos.", "Error");
            }
        }

    }
}
