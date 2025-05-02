using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Models.Pedido;
using TPVproyecto.Services;
using TPVproyecto.Services.Pedidos;

namespace TPVproyecto.ViewModels.PagPedidos
{
    public class PedidosVM : BaseVM
    {
        private NavigationStore _navigationStore;
        private readonly PedidosService _pedidoService;
        private readonly LineasPedidoService _lineasPedidoService;
        public PaginacionHelper<Pedido> PaginacionHelper;

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    FiltrarPedidos();
                }
            }
        }

        public ICommand Anterior { get; set; }
        public ICommand Siguiente { get; set; }
        public ICommand SeleccionarPedidoCommand { get; set; }

        private Pedido _pedidoSeleccionado;
        public Pedido PedidoSeleccionado
        {
            get => _pedidoSeleccionado;
            set
            {
                _pedidoSeleccionado = value;
                OnPropertyChanged(nameof(PedidoSeleccionado));
                CargarLineasPedido(_pedidoSeleccionado);
            }
        }

        private ObservableCollection<Pedido> _pedidos;
        public ObservableCollection<Pedido> Pedidos
        {
            get => _pedidos;
            set
            {
                _pedidos = value;
                OnPropertyChanged(nameof(Pedidos));
            }
        }

        private ObservableCollection<LineaPedido> _lineasPedido;
        public ObservableCollection<LineaPedido> LineasPedido
        {
            get => _lineasPedido;
            set
            {
                _lineasPedido = value;
                OnPropertyChanged(nameof(LineasPedido));
            }
        }

        public PedidosVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _pedidoService = new PedidosService();
            _lineasPedidoService = new LineasPedidoService();

            PaginacionHelper = new PaginacionHelper<Pedido>(new ObservableCollection<Pedido>(_pedidoService.ObtenerPedidos()), 6);
            _pedidos = new ObservableCollection<Pedido>(PaginacionHelper.getPaginaActualElementos());
            _searchQuery = "";
            _lineasPedido = new ObservableCollection<LineaPedido>();

            Anterior = new RelayCommand(
                execute: EjecutarAnterior,
                canExecute: PuedeEjecutarAnterior
            );

            Siguiente = new RelayCommand(
                execute: EjecutarSiguiente,
                canExecute: PuedeEjecutarSiguiente
            );

            SeleccionarPedidoCommand = new RelayCommand(
                execute: EjecutarSeleccionarPedido,
                canExecute: PuedeEjecutarSeleccionarPedido
            );

        }

        private void EjecutarAnterior(object parameter)
        {
            PaginacionHelper.anteriorPag();
            ActualizarColeccion(Pedidos, PaginacionHelper.getPaginaActualElementos());

            ((RelayCommand)Anterior).OnCanExecuteChanged();
            ((RelayCommand)Siguiente).OnCanExecuteChanged();
        }

        private void EjecutarSiguiente(object parameter)
        {
            PaginacionHelper.siguientePag();
            ActualizarColeccion(Pedidos, PaginacionHelper.getPaginaActualElementos());

            ((RelayCommand)Anterior).OnCanExecuteChanged();
            ((RelayCommand)Siguiente).OnCanExecuteChanged();
        }

        private void EjecutarSeleccionarPedido(object parameter)
        {
            if (parameter is Pedido pedido)
            {
                PedidoSeleccionado = pedido;
                CargarLineasPedido(pedido);
            }
        }

        private bool PuedeEjecutarSeleccionarPedido(object parameter)
        {
            return parameter is Pedido;
        }

        private void CargarLineasPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                var lineas = _lineasPedidoService.ObtenerLineasPedidoPorPedido(pedido.ID_Pedido);
                ActualizarColeccion(LineasPedido, lineas);
            }
        }

        private void ActualizarColeccion<T>(ObservableCollection<T> coleccion, IEnumerable<T> nuevosElementos)
        {
            coleccion.Clear();
            foreach (var item in nuevosElementos)
            {
                coleccion.Add(item);
            }
        }

        private void FiltrarPedidos()
        {
            var pedidosFiltrados = string.IsNullOrEmpty(SearchQuery)
                ? PaginacionHelper.getPaginaActualElementos()
                : PaginacionHelper.getPaginaActualElementos().Where(p => p.ID_Pedido.ToString().Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            ActualizarColeccion(Pedidos, pedidosFiltrados);
        }

        public bool PuedeEjecutarSiguiente(object parameter) => PaginacionHelper.ActualPagina < PaginacionHelper.TotalPages;
        public bool PuedeEjecutarAnterior(object parameter) => PaginacionHelper.ActualPagina > 1;
    }
}
