using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPVproyecto.Database;
using TPVproyecto.Models;

namespace TPVproyecto.Services.Tipos
{
    public class AdminTipoService
    {
        private readonly DBContexto _context = new DBContexto();
        // Contructor
        public AdminTipoService() { }

        public void guardarTipoBBDD(Tipo tipo)
        {
            try
            {
                if(tipo != null)
                {
                    Tipo actualizaTipo = _context.Tipo.FirstOrDefault(t => t.Id == tipo.Id); // actualizaTipo --> cojo el tipo con esa ID y luego le cambio los parametros
                    actualizaTipo.NombreTipo = tipo.NombreTipo;

                    // Actualizamos
                    _context.Tipo.Update(actualizaTipo);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("No se pudo guardar el tipo inidicado", "Error");
            }
            
        }

        // Crear tipo
        public void crearTipoBBDD(Tipo tipo)
        {
            try
            {
                Tipo nuevoTipo = new Tipo();
                nuevoTipo.NombreTipo = tipo.NombreTipo;
                _context.Tipo.Add(nuevoTipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el tipo inidicado", "Error");
            }

        }
    }
}
