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

namespace TPVproyecto.ViewModels
{
    public class ElegirToppingVM : BaseVM
    {

        public ObservableCollection<Topping> Toppings { get; set; } // Obtengo los tipos de la BBDD
        public Topping SelectedTopping { get; set; } // Tipo elegido
        private ElegirService _dataService { get; set; }

        public ElegirVM _mainViewModel; // ViewModel de la clase contenedora

        // COMMANDS
        public ICommand SeleccionarCommand { get; set; }

        public ElegirToppingVM(ElegirVM elegirViewModel) {
            _mainViewModel = elegirViewModel;
            _dataService = new ElegirService();
            Toppings = new ObservableCollection<Topping>(_dataService.obtenerToppings());
            SeleccionarCommand = new ElegirCommand(_mainViewModel); // COMANDO
        }
    }
}
