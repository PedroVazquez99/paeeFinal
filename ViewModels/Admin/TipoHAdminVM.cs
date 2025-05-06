using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Commands.AdminModal;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels.Admin
{
    public class TipoHAdminVM : BaseVM
    {
        private int _paginaActual = 1;
        private const int ElementosPorPagina = 5;

        public int PaginaActual
        {
            get => _paginaActual;
            set
            {
                _paginaActual = value;
                OnPropertyChanged(nameof(PaginaActual));
                OnPropertyChanged(nameof(TiposVisibles));
            }
        }

        public ObservableCollection<Tipo> Tipos { get; set; }

        public ObservableCollection<Tipo> TiposVisibles
            => new ObservableCollection<Tipo>(Tipos.Skip((PaginaActual - 1) * ElementosPorPagina).Take(ElementosPorPagina));

        public ICommand CambiarPaginaCommand { get; }
        public ICommand ModalEditarCommand {  get; }

        ElegirService _elegirService;

        public TipoHAdminVM()
        {
            _elegirService = new ElegirService();
            Tipos = new ObservableCollection<Tipo>(_elegirService.obtenerTipos());
            ModalEditarCommand = new EditarTipoModalCommand();

            CambiarPaginaCommand = new RelayCommand(param =>
            {
                int nuevaPagina = PaginaActual + Convert.ToInt32(param);
                if (nuevaPagina > 0 && nuevaPagina <= (Tipos.Count + ElementosPorPagina - 1) / ElementosPorPagina)
                {
                    PaginaActual = nuevaPagina;
                }
            });
        }
    }
}
