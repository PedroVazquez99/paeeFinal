using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Models;
using TPVproyecto.ViewModels.Admin.AdminModalVM;
using TPVproyecto.Views.Paginas.Admin.AdminModal;

namespace TPVproyecto.Commands.AdminModal
{
    // COMANDO: Al hacer click en un item del listado de Tipos
    public class EditarTipoModalCommand : CommandBase
    {
        public Tipo _tipo;

        public EditarTipoModalCommand() {
            
        }

        public override void Execute(object? parameter)
        {
            if(parameter is Tipo) // Comprobamos que la variable sea de tipo --> TIPO
            {
                // Crear una nueva instancia del ViewModel de edición
                var editarTipoModalVM = new EditarTipoModalVM((Tipo)parameter);

                // Crear la ventana y asignarle el DataContext
                var editWindow = new EditarTipoWindow
                {
                    DataContext = editarTipoModalVM
                };

                // Cerrar la ventana cuando el ViewModel lo solicite
                editarTipoModalVM.CloseWindowRequested += () => editWindow.Close();

                // Mostrar la ventana
                editWindow.ShowDialog();
            }
        }
    }
}
