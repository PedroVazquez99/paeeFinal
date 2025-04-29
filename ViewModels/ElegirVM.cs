using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Interfaces;
using TPVproyecto.Models;
using TPVproyecto.ViewModels;

namespace TPVproyecto.ViewModels
{
    public class ElegirVM : BaseVM
    {
        // Navegacion
        private BaseVM _currentViewModel;
        public BaseVM CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        
        public ICommand AceptarElegir { get; }

        // Popiedades
        private Tipo _tipoSeleccionado;
        public Tipo TipoSeleccionado { 
            get => _tipoSeleccionado;
            set 
            {
                _tipoSeleccionado = value;
                OnPropertyChanged(nameof(TipoSeleccionado));
            } 
        }

        private Tamanyo _tamanyoSeleccionado;
        public Tamanyo TamanyoSeleccionado
        {
            get => _tamanyoSeleccionado;
            set
            {
                _tamanyoSeleccionado = value;
                OnPropertyChanged(nameof(TamanyoSeleccionado));
            }
        }

        private Sabor _saborSeleccionado;
        public Sabor SaborSeleccionado
        {
            get => _saborSeleccionado;
            set
            {
                _saborSeleccionado = value;
                OnPropertyChanged(nameof(SaborSeleccionado));
            }
        }

        private Topping _toppingSeleccionado;
        public Topping ToppingSeleccionado
        {
            get => _toppingSeleccionado;
            set
            {
                _toppingSeleccionado = value;
                OnPropertyChanged(nameof(ToppingSeleccionado));
            }
        }

        // Info mostrar
        private readonly BaseVM _tiposViewModel;
        private readonly BaseVM _tamanosViewModel;
        private readonly BaseVM _saboresViewModel;
        private readonly BaseVM _toppingsViewModel;

        private InicioVM _mainWindowVM;

        // CONTRUCTOR
        public ElegirVM(InicioVM mainWindowVM) {

            _mainWindowVM = mainWindowVM;
            _tiposViewModel = new ElegirTipoVM(this);
            _tamanosViewModel = new ElegirTamanyoVM(this);
            _saboresViewModel = new ElegirSaborVM(this);
            _toppingsViewModel = new ElegirToppingVM(this);

            
            
            AceptarElegir = new AceptarElegirCommand(_mainWindowVM, _tipoSeleccionado);

            CurrentViewModel = _tiposViewModel;
        }


        // METODOS
        public void SeleccionarTipoH(Tipo tipo) // Al hacer click en un TIPO
        {
            TipoSeleccionado = tipo;
            CurrentViewModel = _tamanosViewModel;
        }

        public void SeleccionarTamanyoH(Tamanyo tamanyo) // Al hacer click en un tamanyo
        {
            TamanyoSeleccionado = tamanyo;
            CurrentViewModel = _saboresViewModel;
        }

        public void SeleccionarSaborH(Sabor sabor) // Al hacer click en un Sabor
        {
           SaborSeleccionado = sabor;
           CurrentViewModel = _toppingsViewModel;
        }

        public void SeleccionarToppingH(Topping topping) // Al hacer click en un Topping
        {
            ToppingSeleccionado = topping;
            Helado nuevoHelado = new Helado();
            nuevoHelado.TipoH = TipoSeleccionado;
            nuevoHelado.TamanyoH = TamanyoSeleccionado;
            nuevoHelado.SaboresH = SaborSeleccionado;
            nuevoHelado.ToppingsH = ToppingSeleccionado;
            agregarHelado(nuevoHelado);
            
            CurrentViewModel = _tiposViewModel;
        }

        public void agregarHelado(Helado nuevoHelado)
        {
            _mainWindowVM.agregarHelado(nuevoHelado);
        }

    }
}
