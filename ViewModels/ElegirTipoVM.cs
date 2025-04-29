using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels
{
    // ELEGIR TIPO
    public class ElegirTipoVM : BaseVM
    {
        private readonly ElegirService _dataService; // servicio BBDD
        
        public ObservableCollection<Tipo> Tipos { get; set; } // Obtengo los tipos de la BBDD
        public Tipo SelectedTipo { get; set; } // Tipo elegido

        public ElegirVM _mainViewModel; // ViewModel de la clase contenedora
       
        public ICommand tipoSubmit {  get; set; }
        public ICommand SeleccionarCommand { get; set; }

        // Paginacion
        public PaginacionHelper<Tipo> PaginacionTipos;
        
        //private ObservableCollection<Tipo> _tiposPaginados { get; set; }
        //public ObservableCollection<Tipo> TiposPaginados {
        //    get => _tiposPaginados;
        //    set
        //    {
        //        _tiposPaginados = value;
        //        OnPropertyChanged(nameof(TiposPaginados));
        //    }
        //}

        public ElegirTipoVM(ElegirVM mainViewModel) // Para inicailizar los datos
        {
            _mainViewModel = mainViewModel;
            _dataService = new ElegirService();
            Tipos = new ObservableCollection<Tipo>(_dataService.obtenerTipos());
            SeleccionarCommand = new ElegirCommand(_mainViewModel); // COMANDO
            //PaginacionTipos = new PaginacionHelper<Tipo>(Tipos, 3);
            //PaginacionTipos.getPaginaActualElementos();
            

        }

    }
}
