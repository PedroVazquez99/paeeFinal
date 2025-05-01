using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPVproyecto.Database;
using TPVproyecto.Models;

namespace TPVproyecto.Services.Sabores
{
    public class AdminSaborService
    {
        private readonly DBContexto _context = new DBContexto();
        // Contructor
        public AdminSaborService() { }

        public void guardarSaborBBDD(Sabor sabor)
        {
            try
            {
                if (sabor != null)
                {
                    Sabor actualizaSabor = _context.Sabor.FirstOrDefault(t => t.Id == sabor.Id); // actualizaSabor --> cojo el sabor con esa ID y luego le cambio los parametros
                    actualizaSabor.SaborNombre = sabor.SaborNombre;

                    // Actualizamos
                    _context.Sabor.Update(actualizaSabor);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el sabor inidicado", "Error");
            }

        }

        // Crear sabor
        public void crearSaborBBDD(Sabor sabor)
        {
            try
            {
                Sabor nuevoSabor = new Sabor();
                nuevoSabor.SaborNombre = sabor.SaborNombre;
                _context.Sabor.Add(nuevoSabor);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el sabor inidicado", "Error");
            }

        }
    }
}
