using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services;
using TPVproyecto.Views.Elegir;

namespace TPVproyecto.ViewModels
{
    public class ElegirTamanyoVM : BaseVM
    {
        public ElegirVM _mainViewModel; // Referencia al ViewModel padre

        public ObservableCollection<Tamanyo> TamanyosVisibles => _mainViewModel.TamanyosVisibles; // Se obtiene desde el padre

        public ICommand SeleccionarCommand { get; }

        public ElegirTamanyoVM(ElegirVM mainViewModel)
        {
            _mainViewModel = mainViewModel;

            // Mantiene la referencia a los datos paginados y la lógica de selección
            SeleccionarCommand = new RelayCommand(obj => _mainViewModel.SeleccionarElemento(obj));
        }
    }
}
