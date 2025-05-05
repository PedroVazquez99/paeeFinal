using System.Collections.ObjectModel;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;

namespace TPVproyecto.ViewModels
{
    public class ElegirTipoVM : BaseVM
    {
        public ElegirVM _mainViewModel; // Referencia al ViewModel padre

        public ObservableCollection<Tipo> TiposVisibles => _mainViewModel.TiposVisibles; // Se obtiene desde el padre

        public ICommand SeleccionarCommand { get; }

        public ElegirTipoVM(ElegirVM mainViewModel)
        {
            _mainViewModel = mainViewModel;

            // Mantiene la referencia a los datos paginados y la lógica de selección
            SeleccionarCommand = new RelayCommand(obj => _mainViewModel.SeleccionarElemento(obj));
        }
    }
}
