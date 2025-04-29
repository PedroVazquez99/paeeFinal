using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands.AdminModal;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels.Admin
{
    public class TamanyoHAdminVM : BaseVM
    {

        private ObservableCollection<Tamanyo> _tamanyos;

        private Tamanyo _tamanyoSeleccionado;

        public ObservableCollection<Tamanyo> Tamanyos
        {
            get => _tamanyos;
            set
            {
                _tamanyos = value;
                OnPropertyChanged(nameof(Tamanyo));
            }
        }

        //Comandos
        public ICommand ModalEditarCommand { get; set; }

        //Servicio
        private ElegirService _elegirService;

        public TamanyoHAdminVM()
        {
            _elegirService = new ElegirService();
            _tamanyos = new ObservableCollection<Tamanyo>(_elegirService.obtenerTamanyos());

            ModalEditarCommand = new EditarTamanyoModalCommand(); // Cambiar por el modal de Tamanyos
        }

    }
}
