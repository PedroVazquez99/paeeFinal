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
    public class EditarSaborModalCommand : CommandBase
    {
        public Sabor _sabor;

        public EditarSaborModalCommand()
        {

        }

        public override void Execute(object? parameter)
        {
            if (parameter is Sabor) // Comprobamos que la variable sea de tipo --> Sabor
            {
                // Crear una nueva instancia del ViewModel de edición
                var editarSaborModalVM = new EditarSaborModalVM((Sabor)parameter);

                // Crear la ventana y asignarle el DataContext
                var editWindow = new EditarSaborWindow
                {
                    DataContext = editarSaborModalVM
                };

                // Cerrar la ventana cuando el ViewModel lo solicite
                editarSaborModalVM.CloseWindowRequested += () => editWindow.Close();

                // Mostrar la ventana
                editWindow.ShowDialog();
            }
        }
    }
}
