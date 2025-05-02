using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPVproyecto.Models;
using System.Configuration;
using TPVproyecto.Models.Pedido; // esta en una carpeta aparte

namespace TPVproyecto.Database
{
    internal class DBContexto : DbContext
    {

        public string SQLMicrosoft { get { return ConfigurationManager.AppSettings["SQLMicrosoft"]; } }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SQLMicrosoft);
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<LineaPedido> Lineas_Pedido { get; set; }

        // Helado
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Tamanyo> Tamanyo { get; set; }
        public DbSet<Sabor> Sabor { get; set; }
        public DbSet<Topping> Topping { get; set; }

        // Mesa
        public DbSet<Mesa> Mesa { get; set; }


    }
}
