using System.Collections.ObjectModel;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;

namespace TPVproyecto.ViewModels
{
    public class ElegirToppingVM : BaseVM
    {
        public ElegirVM _mainViewModel; // Referencia al ViewModel padre

        public ObservableCollection<Topping> ToppingsVisibles => _mainViewModel.ToppingsVisibles; // Recibe los elementos paginados

        public ICommand SeleccionarCommand { get; }

        public ElegirToppingVM(ElegirVM mainViewModel)
        {
            _mainViewModel = mainViewModel;
            SeleccionarCommand = new RelayCommand(obj => _mainViewModel.SeleccionarElemento(obj));
        }
    }
}
