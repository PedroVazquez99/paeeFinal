using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPVproyecto.Database;
using TPVproyecto.Models;

namespace TPVproyecto.Services.Tamanyos
{
    public class AdminTamanyoService
    {

        private readonly DBContexto _context = new DBContexto();
        // Contructor
        public AdminTamanyoService() { }

        public void guardarTamanyoBBDD(Tamanyo tamanyo)
        {
            try
            {
                if (tamanyo != null)
                {
                    Tamanyo actualizaTamanyo = _context.Tamanyo.FirstOrDefault(t => t.Id == tamanyo.Id); // actualizaTamanyo --> cojo el tamanyo con esa ID y luego le cambio los parametros
                    actualizaTamanyo.NombreTamanyo = tamanyo.NombreTamanyo;
                    actualizaTamanyo.Precio = decimal.Parse(tamanyo.Precio.ToString());

                    // Actualizamos
                    _context.Tamanyo.Update(actualizaTamanyo);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el tamaño inidicado", "Error");
            }

        }

        // Crear tamanyo
        public void crearTamanyoBBDD(Tamanyo tamanyo)
        {
            try
            {
                Tamanyo nuevoTamanyo = new Tamanyo();
                nuevoTamanyo.NombreTamanyo = tamanyo.NombreTamanyo;
                _context.Tamanyo.Add(nuevoTamanyo);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el tamaño inidicado", "Error");
            }

        }

    }
}
