using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services.Tipos;
using TPVproyecto.ViewModels;

public class EditarTipoModalVM : BaseVM
{
    private readonly AdminTipoService _tipoService;

    private Tipo _tipo;
    public Tipo Tipo
    {
        get => _tipo;
        set
        {
            _tipo = value;
            OnPropertyChanged(nameof(Tipo));
        }
    }

    // Nuevo atributo para diferenciar entre crear y editar
    public bool EsNuevo { get; }

    // Comandos
    public ICommand GuardarCommand { get; }
    public ICommand CancelarCommand { get; }

    // Evento para cerrar la ventana
    public event Action CloseWindowRequested;

    // Constructor modificado para identificar si es una creación o edición
    public EditarTipoModalVM(Tipo tipo)
    {
        _tipoService = new AdminTipoService();

        EsNuevo = tipo == null; // Si el tipo es nulo, significa que se está creando uno nuevo
        Tipo = tipo ?? new Tipo(); // Si no hay tipo, inicializamos uno nuevo

        GuardarCommand = new RelayCommand(
            execute: Guardar,
            canExecute: PuedeEjecutarGuardar
        );

        CancelarCommand = new RelayCommand(
            execute: Cancelar,
            canExecute: _ => true
        );
    }

    private void Guardar(object parameter)
    {
        if (EsNuevo)
        {
            _tipoService.crearTipoBBDD(Tipo); // Método para crear un nuevo tipo
            
        }
        else
        {
            _tipoService.guardarTipoBBDD(Tipo); // Método para actualizar el tipo existente
        }
        
        CloseWindowRequested?.Invoke();
    }

    private void Cancelar(object parameter)
    {
        CloseWindowRequested?.Invoke();
    }

    public bool PuedeEjecutarGuardar(object parameter)
    {
        // return !string.IsNullOrWhiteSpace(Tipo.NombreTipo); // 🔄 Validar que el nombre no esté vacío
        return true;
    }
}
