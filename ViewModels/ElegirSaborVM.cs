using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels
{
    public class ElegirSaborVM : BaseVM
    {
        private readonly ElegirService _dataService; // servicio obtener los tipos de la BBDD
        public List<Sabor> Sabores { get; set; } // Obtengo los tipos de la BBDD
        public ICommand SeleccionarCommand { get; set; }
        private readonly ElegirVM _elegirVM;

        public ElegirSaborVM(ElegirVM elegirVM)
        {
            _elegirVM = elegirVM;
            _dataService = new ElegirService();
            Sabores = new List<Sabor>(_dataService.obtenerSabores());
            SeleccionarCommand = new ElegirCommand(elegirVM);
        }
    }
}
