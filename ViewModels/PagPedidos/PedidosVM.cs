using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        NavigationStore _navigationStore;
        PedidosService _pedidoService;
        public PaginacionHelper<Pedido> PaginacionHelper;

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    FiltrarPedidos(Pedidos, _searchQuery);
                }
            }
        }

        
        public ICommand Anterior { get; set; }
        public ICommand Siguiente {  get; set; }

        private ObservableCollection<Pedido> _pedidos;
        public ObservableCollection<Pedido> Pedidos {
            get => _pedidos;
            set { 
                _pedidos = value;
                OnPropertyChanged(nameof(Pedidos));
            }
        
        }

        public PedidosVM(NavigationStore navigationStore) {
            _navigationStore = navigationStore;
            _pedidoService = new PedidosService();
            PaginacionHelper = new PaginacionHelper<Pedido>(new ObservableCollection<Pedido>(_pedidoService.obtenerPedido()), 6);
            _pedidos = new ObservableCollection<Pedido>(PaginacionHelper.getPaginaActualElementos());
            _searchQuery = "";

            Anterior = new RelayCommand(
                execute: EjecutarAnterior,
                canExecute: PuedeEjecutarAnterior
            );

            Siguiente = new RelayCommand(
                execute: EjecutarSiguiente,
                canExecute: PuedeEjecutarSiguiente
            );



        }

        public ObservableCollection<Pedido> obtenerLista()
        {

            return _pedidos;
        }

        private void EjecutarAnterior(object parameter)
        {
            PaginacionHelper.anteriorPag();
            ActualizarColeccion(_pedidos, PaginacionHelper.getPaginaActualElementos());

            ((RelayCommand)Anterior).OnCanExecuteChanged(); 
            ((RelayCommand)Siguiente).OnCanExecuteChanged();
        }

        private void EjecutarSiguiente(object parameter)
        {
            PaginacionHelper.siguientePag();
            ActualizarColeccion(_pedidos, PaginacionHelper.getPaginaActualElementos());

            ((RelayCommand)Anterior).OnCanExecuteChanged(); 
            ((RelayCommand)Siguiente).OnCanExecuteChanged();

        }

        private void ActualizarColeccion(ObservableCollection<Pedido> coleccion, IEnumerable<Pedido> nuevosElementos)
        {
            // Limpia la colección existente
            coleccion.Clear();

            // Agrega los nuevos elementos a la colección
            foreach (var item in nuevosElementos)
            {
                coleccion.Add(item);
            }
        }

        public bool PuedeEjecutarSiguiente(object parameter)
        {
            // logica para habilitar el boton de guardar
            return PaginacionHelper.ActualPagina < PaginacionHelper.TotalPages;
        }

        public bool PuedeEjecutarAnterior(object parameter)
        {
            // logica para habilitar el boton de guardar
            return PaginacionHelper.ActualPagina > 1;
        }

        // Método para filtrar los pedidos según el texto de búsqueda
        public ObservableCollection<Pedido> FiltrarPedidos(ObservableCollection<Pedido> pedidos, string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return pedidos;  // Devuelve todos los pedidos si no hay búsqueda
            }
            else
            {
                // return pedidos.Where(p => p.ID_Pedido.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
                return (ObservableCollection<Pedido>)pedidos.Where(p => p.ID_Pedido.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
