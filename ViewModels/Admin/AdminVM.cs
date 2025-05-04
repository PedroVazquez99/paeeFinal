using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels.Admin
{
    public class AdminVM : BaseVM
    {
        private NavigationStore _navigationStore;
        private object _currentViewAdmin;

        public object CurrentViewAdmin
        {
            get { return _currentViewAdmin; }
            set { _currentViewAdmin = value; OnPropertyChanged(nameof(CurrentViewAdmin)); }
        }



        public AdminVM(NavigationStore navigationStore) {
            _navigationStore = navigationStore;

            VolverCommand = new VolverCommand(navigationStore); // Boton de Volver (Atras)

            TipoCommand = new RelayCommand(TipoAdmin);
            TamanyoCommand = new RelayCommand(TamanyoAdmin);
            SaborCommand = new RelayCommand(SaborAdmin);

            // Pagina de Inicio
            CurrentViewAdmin = new TipoHAdminVM();
        }


        // Comandos
        public ICommand TipoCommand { get; set; }
        public ICommand TamanyoCommand { get; set; }
        public ICommand SaborCommand { get; set; }
        public ICommand VolverCommand { get; set; }

        // Vistas
        private void TipoAdmin(object obj) => CurrentViewAdmin = new TipoHAdminVM();
        private void TamanyoAdmin(object obj) => CurrentViewAdmin = new TamanyoHAdminVM();
        private void SaborAdmin(object obj) => CurrentViewAdmin = new SaborHAdminVM();
    }
}
