using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.ViewModels.Admin;
using TPVproyecto.Views.Paginas.Admin.AdminModal;

namespace TPVproyecto.Commands
{
    public class AddCommand : CommandBase
    {
        public object _currentViewAdmin; // Para determinar que viewModel es y poder añadir un objeto u otro

        public AddCommand(object currentViewAdmin) {
            _currentViewAdmin = currentViewAdmin;
        }

        public override void Execute(object? parameter)
        {
            switch (_currentViewAdmin)
            {
                case TipoHAdminVM:
                    var vm = new EditarTipoModalVM(null); // 🔄 Indicar que se está creando un nuevo tipo
                    var ventana = new EditarTipoWindow { DataContext = vm };
                    ventana.ShowDialog();
                    break;
                case SaborHAdminVM:
                    Console.WriteLine('s');
                    break;
                case TamanyoHAdminVM:
                    Console.WriteLine('m');
                    break;
                case null:
                    Console.WriteLine('a');
                    break;
            }
        }

        public void setCurrentView(object currentView)
        {
            if(currentView != null)
            {
                _currentViewAdmin = currentView;
            }
        }
    }
}
