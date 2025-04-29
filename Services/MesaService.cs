using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Models;

namespace TPVproyecto.Services
{
    public class MesaService
    {
        SqlConnection connection; // Cadena de conexion
        private ObservableCollection<Mesa> _mesasList; // Listado de mesas de la BBDD

        public MesaService() { 
            connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]);
            _mesasList = new ObservableCollection<Mesa>();
        }

        // Obtener todas las mesas
        public ObservableCollection<Mesa> obtenerMesas()
        {
            ObservableCollection<Mesa> mesas = new ObservableCollection<Mesa>();

            connection.Open();
            string query = "SELECT id, nombreMesa, isActivo FROM Mesa";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Mesa mesasBBDD = new Mesa
                        {
                            Id = (int)reader.GetInt32(0), // Columna Id,
                            NombreMesa = reader.GetString(1),
                            IsActivo = reader.GetBoolean(2)

                        };
                        mesas.Add(mesasBBDD);

                        Console.WriteLine(reader);
                    }
                }
            }
            _mesasList = mesas;
            return _mesasList;
            
        }

        public void cambiarEstadoMesa(int idMesa, bool nuevoEstado)
        {
            try
            {
                connection.Open();
                string query = "UPDATE Mesa SET isActivo = @nuevoEstado WHERE id = @idMesa";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                    command.Parameters.AddWithValue("@idMesa", idMesa);

                    int filasAfectadas = command.ExecuteNonQuery(); // Ejecuta la actualización

                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine($"Mesa con Id {idMesa} actualizada a IsActivo = {nuevoEstado}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró la mesa para actualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar el estado de la mesa: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
