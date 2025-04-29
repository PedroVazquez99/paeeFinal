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
        private readonly ElegirService _dataService;
        public List<Tamanyo> Tamanyos { get; set; }
        private readonly ElegirVM _mainViewModel;
        public ICommand SeleccionarCommand { get; set; }
        public ElegirTamanyoVM()
        {
            _dataService = new ElegirService();
            Tamanyos = new List<Tamanyo>(_dataService.obtenerTamanyos());

        }

        public ElegirTamanyoVM(ElegirVM mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _dataService = new ElegirService();
            Tamanyos = new List<Tamanyo>(_dataService.obtenerTamanyos());
            SeleccionarCommand = new ElegirCommand(_mainViewModel); // COMANDO
        }
    }
}
