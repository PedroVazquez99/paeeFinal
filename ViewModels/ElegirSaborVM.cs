using System.Collections.ObjectModel;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;

namespace TPVproyecto.ViewModels
{
    public class ElegirSaborVM : BaseVM
    {
        public ElegirVM _mainViewModel; // Referencia al ViewModel padre

        public ObservableCollection<Sabor> SaboresVisibles => _mainViewModel.SaboresVisibles; // Recibe los elementos paginados

        public ICommand SeleccionarCommand { get; }

        public ElegirSaborVM(ElegirVM mainViewModel)
        {
            _mainViewModel = mainViewModel;
            SeleccionarCommand = new RelayCommand(obj => _mainViewModel.SeleccionarElemento(obj));
        }
    }
}
