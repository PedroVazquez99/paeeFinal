using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services.Tipos;

namespace TPVproyecto.ViewModels.Admin.AdminModalVM
{
    public class EditarTipoModalVM : BaseVM
    {
        // Dato que se va a modificar en la ventana
        AdminTipoService _tipoService;

        private Tipo _tipo { get; set; }
        public Tipo Tipo { 
            get => _tipo;
            set
            {
                _tipo = value;
                OnPropertyChanged(nameof(Tipo));
            }
        }
        // Comandos
        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        // Evento
        public event Action CloseWindowRequested;

        // Constructor
        public EditarTipoModalVM(Tipo tipo) {
            _tipo = tipo;

            // Comando para guardar
            GuardarCommand = new RelayCommand(
                execute: Guardar,
                canExecute: PuedeEjecutarGuardar
             );

            // Comando para cancelar
            CancelarCommand = new RelayCommand(
                execute: Cancelar,
                canExecute: (object parameter) => true
            );

            _tipoService = new AdminTipoService();
        }


        private void Guardar(object parameter)
        {
            // Lógica para guardar el producto (puedes añadir validación aquí)
            // Ejemplo: Actualizar en la base de datos
            _tipoService.guardarTipoBBDD(_tipo);
            CloseWindowRequested?.Invoke();
        }

        private void Cancelar(object parameter)
        {
            // Cierra la ventana sin guardar cambios
            CloseWindowRequested?.Invoke();
        }

        public bool PuedeEjecutarGuardar(object parameter)
        {
            // logica para habilitar el boton de guardar
            return true;
        }
    }
}
