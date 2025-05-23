﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPVproyecto.Database;
using TPVproyecto.Models;
using TPVproyecto.Models.Pedido;

namespace TPVproyecto.Services
{
    public class HeladoService
    {
        private DBContexto _dbContext = new DBContexto();

        public HeladoService()
        {
        }

        public void guardarHelado(ObservableCollection<Helado> heladoList, Mesa mesa)
        {
            decimal precioTotal = 0;

            try
            {
                // Crear un nuevo pedido
                Pedido pedido = new Pedido
                {
                    IdMesa = mesa.Id, // Referencia a la mesa con id 1
                    Fecha = DateTime.Now
                };
                pedido.LineasPedido = new List<LineaPedido>();
                foreach (Helado helado in heladoList)
                {
                    LineaPedido linea = new LineaPedido
                    {
                        ID_Tipo = helado.TipoH.Id, // Tipo de helado (ej. Vainilla)
                        ID_Tamanyo = helado.TamanyoH.Id, // Tamaño (ej. Grande)
                        ID_Sabor = helado.SaboresH.Id, // Sabor (ej. Fresa),
                        ID_Topping = helado.ToppingsH.Id,
                        Subtotal = calcularTotalHelado(helado)
                    };
                    precioTotal += linea.Subtotal;
                    pedido.LineasPedido.Add(linea);
                }
                pedido.Total = precioTotal;

                // Agregar el pedido al contexto
                _dbContext.Pedido.Add(pedido);

                // Guardar los cambios en la base de datos
                _dbContext.SaveChanges();
            }
            catch
            {

                MessageBox.Show("Ha ocurrido un error durante el pago");
            }


        }

        //Calcular total de todos los helados
        public decimal calcularTotal(ObservableCollection<Helado> heladoList)
        {
            decimal total = 0;

            foreach (Helado helado in heladoList)
            {
                if (helado != null)
                {
                    total += helado.TamanyoH.Precio;
                    total += helado.ToppingsH.PrecioPlus;
                }
            }

            return total;
        }

        // Calcular precio de un solo helado
        public decimal calcularTotalHelado(Helado helado)
        {
            decimal total = 0;

            total += helado.TamanyoH.Precio;
            total += helado.ToppingsH.PrecioPlus;

            return total;
        }

        public ObservableCollection<Helado> ObtenerHeladosNoPagados(int idMesa)
        {
            var helados = _dbContext.Pedido
                .Where(p => p.IdMesa == idMesa && !p.IsPagado)
                .SelectMany(p => p.LineasPedido)
                .Select(lp => new Helado
                {
                    Id = lp.ID, // Usamos el ID de la línea como identificador del helado
                    TipoH = _dbContext.Tipo.FirstOrDefault(t => t.Id == lp.ID_Tipo),
                    TamanyoH = _dbContext.Tamanyo.FirstOrDefault(t => t.Id == lp.ID_Tamanyo),
                    SaboresH = _dbContext.Sabor.FirstOrDefault(s => s.Id == lp.ID_Sabor),
                    ToppingsH = _dbContext.Topping.FirstOrDefault(t => t.Id == lp.ID_Topping),
                })
                .ToList();

            return new ObservableCollection<Helado>(helados);
        }


        public void AgregarHeladoAPedido(int idPedido, int idTipo, int idTamanyo, int idSabor, int idTopping)
        {
            try
            {
                using (var contexto = new DBContexto())
                {
                    // Buscar el pedido existente con sus líneas de pedido
                    var pedido = contexto.Pedido
                        .Include(p => p.LineasPedido)
                        .FirstOrDefault(p => p.ID_Pedido == idPedido);

                    if (pedido == null)
                    {
                        throw new Exception("El pedido no existe.");
                    }

                    // Crear la nueva línea de pedido con los IDs proporcionados
                    var nuevaLinea = new LineaPedido
                    {
                        ID_Pedido = idPedido,
                        ID_Tipo = idTipo,
                        ID_Tamanyo = idTamanyo,
                        ID_Sabor = idSabor,
                        ID_Topping = idTopping,
                        Subtotal = contexto.Tamanyo.Where(t => t.Id == idTamanyo).Select(t => t.Precio).FirstOrDefault()
                                 + contexto.Topping.Where(t => t.Id == idTopping).Select(t => t.PrecioPlus).FirstOrDefault()
                    };

                    // Agregar la nueva línea de pedido y actualizar el total del pedido
                    pedido.LineasPedido.Add(nuevaLinea);
                    pedido.Total += nuevaLinea.Subtotal;

                    contexto.SaveChanges(); // Guardar cambios en la base de datos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el helado al pedido: {ex.Message}");
            }
        }

    }
}
