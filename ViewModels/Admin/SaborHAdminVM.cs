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
    public class SaborHAdminVM : BaseVM
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
                    OnPropertyChanged(nameof(SaboresVisibles));
                }
            }
        }

        public int TotalPaginas => (Sabores.Count + ElementosPorPagina - 1) / ElementosPorPagina;

        private ObservableCollection<Sabor> _sabores;
        public ObservableCollection<Sabor> Sabores
        {
            get => _sabores;
            set
            {
                _sabores = value;
                OnPropertyChanged(nameof(Sabores));
                OnPropertyChanged(nameof(SaboresVisibles));
                OnPropertyChanged(nameof(TotalPaginas));
            }
        }

        public ObservableCollection<Sabor> SaboresVisibles =>
            new ObservableCollection<Sabor>(
                Sabores.Skip((PaginaActual - 1) * ElementosPorPagina).Take(ElementosPorPagina)
            );

        public ICommand ModalEditarCommand { get; }
        public ICommand CambiarPaginaCommand { get; }

        private ElegirService _elegirService;

        public SaborHAdminVM()
        {
            _elegirService = new ElegirService();
            Sabores = new ObservableCollection<Sabor>(_elegirService.obtenerSabores());

            ModalEditarCommand = new EditarSaborModalCommand();

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
