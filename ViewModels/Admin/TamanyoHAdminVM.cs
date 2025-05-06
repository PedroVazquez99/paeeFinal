using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Commands.AdminModal;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels.Admin
{
    public class TamanyoHAdminVM : BaseVM
    {
        private int _paginaActual = 1;
        private const int ElementosPorPagina = 5;

        public int PaginaActual
        {
            get => _paginaActual;
            set
            {
                if (_paginaActual != value)
                {
                    _paginaActual = value;
                    OnPropertyChanged(nameof(PaginaActual));
                    OnPropertyChanged(nameof(TamanyosVisibles));
                }
            }
        }

        public int TotalPaginas => (Tamanyos.Count + ElementosPorPagina - 1) / ElementosPorPagina;

        private ObservableCollection<Tamanyo> _tamanyos;
        public ObservableCollection<Tamanyo> Tamanyos
        {
            get => _tamanyos;
            set
            {
                _tamanyos = value;
                OnPropertyChanged(nameof(Tamanyos));
                OnPropertyChanged(nameof(TamanyosVisibles));
                OnPropertyChanged(nameof(TotalPaginas));
            }
        }

        public ObservableCollection<Tamanyo> TamanyosVisibles
            => new ObservableCollection<Tamanyo>(
                Tamanyos.Skip((PaginaActual - 1) * ElementosPorPagina).Take(ElementosPorPagina)
            );

        public ICommand ModalEditarCommand { get; }
        public ICommand CambiarPaginaCommand { get; }

        private ElegirService _elegirService;

        public TamanyoHAdminVM()
        {
            _elegirService = new ElegirService();
            Tamanyos = new ObservableCollection<Tamanyo>(_elegirService.obtenerTamanyos());

            ModalEditarCommand = new EditarTamanyoModalCommand();

            CambiarPaginaCommand = new RelayCommand(param =>
            {
                int nuevaPagina = PaginaActual + Convert.ToInt32(param);
                if (nuevaPagina > 0 && nuevaPagina <= TotalPaginas)
                {
                    PaginaActual = nuevaPagina;
                }
            });
        }
    }
}
