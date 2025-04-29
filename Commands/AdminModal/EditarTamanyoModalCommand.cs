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
    public class EditarTamanyoModalCommand : CommandBase
    {
        public Tamanyo _tamanyo;

        public EditarTamanyoModalCommand()
        {

        }

        public override void Execute(object? parameter)
        {
            if (parameter is Tamanyo) // Comprobamos que la variable sea de tamanyo --> Tamanyos
            {
                // Crear una nueva instancia del ViewModel de edición
                var editarTamanyoModalVM = new EditarTamanyoModalVM((Tamanyo)parameter);

                // Crear la ventana y asignarle el DataContext
                var editWindow = new EditarTamanyoWindow
                {
                    DataContext = editarTamanyoModalVM
                };

                // Cerrar la ventana cuando el ViewModel lo solicite
                editarTamanyoModalVM.CloseWindowRequested += () => editWindow.Close();

                // Mostrar la ventana
                editWindow.ShowDialog();
            }
        }
    }
}
