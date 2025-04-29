using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services.Tamanyos;

namespace TPVproyecto.ViewModels.Admin.AdminModalVM
{
    public class EditarTamanyoModalVM : BaseVM
    {
        // Dato que se va a modificar en la ventana
        AdminTamanyoService _tamanyoService;

        private Tamanyo _tamanyo { get; set; }
        public Tamanyo Tamanyo
        {
            get => _tamanyo;
            set
            {
                _tamanyo = value;
                OnPropertyChanged(nameof(Tamanyo));
            }
        }
        // Comandos
        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        // Evento
        public event Action CloseWindowRequested;

        // Constructor
        public EditarTamanyoModalVM(Tamanyo tamanyo)
        {
            _tamanyo = tamanyo;

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

            _tamanyoService = new AdminTamanyoService();
        }


        private void Guardar(object parameter)
        {
            // Lógica para guardar el producto (puedes añadir validación aquí)
            // Ejemplo: Actualizar en la base de datos
            _tamanyoService.guardarTamanyoBBDD(_tamanyo);
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
