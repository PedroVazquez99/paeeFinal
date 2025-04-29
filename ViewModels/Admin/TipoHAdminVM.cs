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

        private ObservableCollection<Tipo> _tipos;

        private Tipo _tipoSeleccionado;

        public ObservableCollection<Tipo> Tipos {
            get => _tipos;
            set 
            {
                _tipos = value;
                OnPropertyChanged(nameof(Tipos));
            }    
        }

        //Comandos
        public ICommand ModalEditarCommand { get; set; }

        //Servicio
        private ElegirService _elegirService;

        public TipoHAdminVM() {
            _elegirService = new ElegirService();
            _tipos = new ObservableCollection<Tipo>(_elegirService.obtenerTipos());

            ModalEditarCommand = new EditarTipoModalCommand();
        }



    }
}
