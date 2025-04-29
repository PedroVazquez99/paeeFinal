using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Database;
using TPVproyecto.Models;
using TPVproyecto.Models.Pedido;

namespace TPVproyecto.Services.Pedidos
{
    public class PedidosService
    {
        public List<Pedido> obtenerPedido()
        {
            var Pedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]))
            {
                connection.Open();
                string query = "SELECT ID_Pedido, idMesa, Fecha, Total, IsPagado FROM Pedido";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedidoBBDD = new Pedido
                            {
                                ID_Pedido = reader.GetInt32(0), // Columna Nombre
                                IdMesa = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                Total = reader.GetDecimal(3),
                                IsPagado = reader.GetBoolean(4),
    
                            };
                            Pedidos.Add(pedidoBBDD);
                            // Ahora, con el IdMesa, obtenemos el NombreMesa
                        pedidoBBDD.Mesa = ObtenerMesa(pedidoBBDD.IdMesa);
                            Console.WriteLine(reader);
                        }
                    }
                }
            }

            return Pedidos;
        }


        // Método adicional para obtener los detalles de la Mesa
        private Mesa ObtenerMesa(int idMesa)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]))
            {
                connection.Open();
                string query = "SELECT NombreMesa FROM Mesa WHERE id = @idMesa";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idMesa", idMesa);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Mesa
                            {
                                NombreMesa = reader.GetString(0)
                            };
                        }
                    }
                }
            }

            return null;
        }

    }

}
