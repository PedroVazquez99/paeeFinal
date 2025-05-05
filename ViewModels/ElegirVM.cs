using System.Collections.ObjectModel;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels
{
    public class ElegirVM : BaseVM
    {
        private readonly ElegirService _dataService;

        // Paginación para cada categoría
        private readonly PaginacionHelper<Tipo> _paginacionTipos;
        private readonly PaginacionHelper<Tamanyo> _paginacionTamanyos;
        private readonly PaginacionHelper<Sabor> _paginacionSabores;
        private readonly PaginacionHelper<Topping> _paginacionToppings;

        // Colecciones visibles
        public ObservableCollection<Tipo> TiposVisibles { get; private set; }
        public ObservableCollection<Tamanyo> TamanyosVisibles { get; private set; }
        public ObservableCollection<Sabor> SaboresVisibles { get; private set; }
        public ObservableCollection<Topping> ToppingsVisibles { get; private set; }

        // Propiedades seleccionadas
        public Tipo TipoSeleccionado { get; set; }
        public Tamanyo TamanyoSeleccionado { get; set; }
        public Sabor SaborSeleccionado { get; set; }
        public Topping ToppingSeleccionado { get; set; }

        // Vista actual
        private BaseVM _currentViewModel;
        public BaseVM CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
                ActualizarElementosVisibles();
            }
        }

        // Comandos de navegación y selección
        public ICommand SiguientePaginaCommand { get; }
        public ICommand AnteriorPaginaCommand { get; }
        public ICommand SeleccionarElementoCommand { get; }

        InicioVM _mainVM { get; set; }

        public ElegirVM(InicioVM mainVM)
        {
            _dataService = new ElegirService();

            var tipos = _dataService.obtenerTipos();
            var tamanyos = _dataService.obtenerTamanyos();
            var sabores = _dataService.obtenerSabores();
            var toppings = _dataService.obtenerToppings();

            // Inicializar paginación
            _paginacionTipos = new PaginacionHelper<Tipo>(tipos, 6);
            _paginacionTamanyos = new PaginacionHelper<Tamanyo>(tamanyos, 6);
            _paginacionSabores = new PaginacionHelper<Sabor>(sabores, 6);
            _paginacionToppings = new PaginacionHelper<Topping>(toppings, 6);

            // Inicializar listas visibles
            TiposVisibles = new ObservableCollection<Tipo>(_paginacionTipos.getPaginaActualElementos());
            TamanyosVisibles = new ObservableCollection<Tamanyo>(_paginacionTamanyos.getPaginaActualElementos());
            SaboresVisibles = new ObservableCollection<Sabor>(_paginacionSabores.getPaginaActualElementos());
            ToppingsVisibles = new ObservableCollection<Topping>(_paginacionToppings.getPaginaActualElementos());

            // Comandos de navegación y selección
            SiguientePaginaCommand = new RelayCommand(_ => CambiarPagina(true));
            AnteriorPaginaCommand = new RelayCommand(_ => CambiarPagina(false));
            SeleccionarElementoCommand = new RelayCommand(obj => SeleccionarElemento(obj));

            // Vista inicial
            CurrentViewModel = new ElegirTipoVM(this);
            _mainVM = mainVM;
        }

        private void CambiarPagina(bool siguiente)
        {
            switch (CurrentViewModel)
            {
                case ElegirTipoVM:
                    if (siguiente) _paginacionTipos.siguientePag();
                    else _paginacionTipos.anteriorPag();

                    TiposVisibles.Clear();
                    foreach (var item in _paginacionTipos.getPaginaActualElementos())
                        TiposVisibles.Add(item);

                    OnPropertyChanged(nameof(TiposVisibles));
                    break;

                case ElegirTamanyoVM:
                    if (siguiente) _paginacionTamanyos.siguientePag();
                    else _paginacionTamanyos.anteriorPag();

                    TamanyosVisibles.Clear();
                    foreach (var item in _paginacionTamanyos.getPaginaActualElementos())
                        TamanyosVisibles.Add(item);

                    OnPropertyChanged(nameof(TamanyosVisibles));
                    break;

                case ElegirSaborVM:
                    if (siguiente) _paginacionSabores.siguientePag();
                    else _paginacionSabores.anteriorPag();

                    SaboresVisibles.Clear();
                    foreach (var item in _paginacionSabores.getPaginaActualElementos())
                        SaboresVisibles.Add(item);

                    OnPropertyChanged(nameof(SaboresVisibles));
                    break;

                case ElegirToppingVM:
                    if (siguiente) _paginacionToppings.siguientePag();
                    else _paginacionToppings.anteriorPag();

                    ToppingsVisibles.Clear();
                    foreach (var item in _paginacionToppings.getPaginaActualElementos())
                        ToppingsVisibles.Add(item);

                    OnPropertyChanged(nameof(ToppingsVisibles));
                    break;
            }
        }


        public void SeleccionarElemento(object elemento)
        {
            if (elemento is Tipo tipo)
            {
                TipoSeleccionado = tipo;
                CurrentViewModel = new ElegirTamanyoVM(this);
            }
            else if (elemento is Tamanyo tamanyo)
            {
                TamanyoSeleccionado = tamanyo;
                CurrentViewModel = new ElegirSaborVM(this);
            }
            else if (elemento is Sabor sabor)
            {
                SaborSeleccionado = sabor;
                CurrentViewModel = new ElegirToppingVM(this);
            }
            else if (elemento is Topping topping)
            {
                ToppingSeleccionado = topping;
                AgregarHelado();
            }

            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void AgregarHelado()
        {
            var nuevoHelado = new Helado
            {
                TipoH = TipoSeleccionado,
                TamanyoH = TamanyoSeleccionado,
                SaboresH = SaborSeleccionado,
                ToppingsH = ToppingSeleccionado
            };

            // Guardar el helado en la aplicación
            // Aquí puedes llamar a un método de la VM principal
            _mainVM.agregarHelado(nuevoHelado);
            // Reiniciar selección
            TipoSeleccionado = null;
            TamanyoSeleccionado = null;
            SaborSeleccionado = null;
            ToppingSeleccionado = null;
            CurrentViewModel = new ElegirTipoVM(this);
        }

        private void ActualizarElementosVisibles()
        {
            switch (CurrentViewModel)
            {
                case ElegirTipoVM:
                    TiposVisibles = new ObservableCollection<Tipo>(_paginacionTipos.getPaginaActualElementos());
                    OnPropertyChanged(nameof(TiposVisibles));
                    break;

                case ElegirTamanyoVM:
                    TamanyosVisibles = new ObservableCollection<Tamanyo>(_paginacionTamanyos.getPaginaActualElementos());
                    OnPropertyChanged(nameof(TamanyosVisibles));
                    break;

                case ElegirSaborVM:
                    SaboresVisibles = new ObservableCollection<Sabor>(_paginacionSabores.getPaginaActualElementos());
                    OnPropertyChanged(nameof(SaboresVisibles));
                    break;

                case ElegirToppingVM:
                    ToppingsVisibles = new ObservableCollection<Topping>(_paginacionToppings.getPaginaActualElementos());
                    OnPropertyChanged(nameof(ToppingsVisibles));
                    break;
            }
        }



    }
}
