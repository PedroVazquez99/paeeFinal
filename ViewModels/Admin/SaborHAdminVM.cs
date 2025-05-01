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
    public class SaborHAdminVM : BaseVM
    {
        private ObservableCollection<Sabor> _sabores;

        private Sabor _saborSeleccionado;

        public ObservableCollection<Sabor> Sabores
        {
            get => _sabores;
            set
            {
                _sabores = value;
                OnPropertyChanged(nameof(Sabores));
            }
        }

        //Comandos
        public ICommand ModalEditarCommand { get; set; }

        //Servicio
        private ElegirService _elegirService;

        public SaborHAdminVM()
        {
            _elegirService = new ElegirService();
            _sabores = new ObservableCollection<Sabor>(_elegirService.obtenerSabores());

            ModalEditarCommand = new EditarSaborModalCommand(); // Cambiar por el modal de Tamanyos
        }

    }
}
