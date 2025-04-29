using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Models;

namespace TPVproyecto.Services
{
    public class ElegirService
    {

        // Simulación de base de datos
        private List<Tipo> _tipos = new List<Tipo>();
        private List<Tamanyo> _tamanyos = new List<Tamanyo>();
        private List<Sabor> _sabores = new List<Sabor>();
        private List<Topping> _topping = new List<Topping>();

        // FUNCIONES
        public List<Tipo> getTipos() => _tipos;
        public List<Tamanyo> getTamanyos() => _tamanyos;
        public List<Sabor> Sabores() => _sabores;
        public List<Topping> getTopping() => _topping;

        //OBTENER TIPOS
        public List<Tipo> obtenerTipos()
        {
            var tipos = new List<Tipo>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]))
            {
                connection.Open();
                string query = "SELECT id, nombreTipo FROM Tipo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tipo tiposBBDD = new Tipo
                            {
                                Id = (int)reader.GetInt32(0), // Columna Id
                                NombreTipo = reader.GetString(1) // Columna Nombre

                            };
                            tipos.Add(tiposBBDD);

                            Console.WriteLine(reader);
                        }
                    }
                }
            }

            return tipos;
        }

        //OBTENER TAMANYOS
        public List<Tamanyo> obtenerTamanyos()
        {
            var tamanyos = new List<Tamanyo>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]))
            {
                connection.Open();
                string query = "SELECT id, nombreTamanyo, precio FROM Tamanyo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tamanyo tamanyoBBDD = new Tamanyo
                            {
                                Id = (int)reader.GetInt32(0), // Columna Id
                                NombreTamanyo = reader.GetString(1), // Columna Nombre
                                Precio = reader.GetDecimal(2)

                            };
                            tamanyos.Add(tamanyoBBDD);

                            Console.WriteLine(reader);
                        }
                    }
                }
            }

            return tamanyos;
        }

        //OBTENER SABORES
        public List<Sabor> obtenerSabores()
        {
            var sabores = new List<Sabor>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]))
            {
                connection.Open();
                string query = "SELECT id, saborNombre FROM Sabor";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sabor tamanyoBBDD = new Sabor
                            {
                                Id = (int)reader.GetInt32(0), // Columna Id
                                SaborNombre = reader.GetString(1) // Columna Nombre
                                

                            };
                            sabores.Add(tamanyoBBDD);

                            Console.WriteLine(reader);
                        }
                    }
                }
            }

            return sabores;
        }

        //OBTENER SABORES
        public List<Topping> obtenerToppings()
        {
            var toppings = new List<Topping>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["SQLMicrosoft"]))
            {
                connection.Open();
                string query = "SELECT id, toppingNombre FROM Topping";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Topping toppingBBDD = new Topping
                            {
                                Id = (int)reader.GetInt32(0), // Columna Id
                                ToppingNombre = reader.GetString(1) // Columna Nombre

                            };
                            toppings.Add(toppingBBDD);

                            Console.WriteLine(reader);
                        }
                    }
                }
            }

            return toppings;
        }


    }

}