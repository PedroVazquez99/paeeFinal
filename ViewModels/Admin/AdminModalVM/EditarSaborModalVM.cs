using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services.Sabores;

namespace TPVproyecto.ViewModels.Admin.AdminModalVM
{
    public class EditarSaborModalVM : BaseVM
    {
        // Dato que se va a modificar en la ventana
        AdminSaborService _saborService;

        private Sabor _sabor { get; set; }
        public Sabor Sabor
        {
            get => _sabor;
            set
            {
                _sabor = value;
                OnPropertyChanged(nameof(Sabor));
            }
        }
        // Comandos
        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        // Evento
        public event Action CloseWindowRequested;

        // Constructor
        public EditarSaborModalVM(Sabor sabor)
        {
            _sabor = sabor;

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

            _saborService = new AdminSaborService();
        }


        private void Guardar(object parameter)
        {
            // Lógica para guardar el producto (puedes añadir validación aquí)
            // Ejemplo: Actualizar en la base de datos
            _saborService.guardarSaborBBDD(_sabor);
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
