using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;

namespace TPVproyecto.ViewModels
{
    public class PedidoVM : BaseVM
    {

        
        // Total cuenta
        private decimal _total = 0.00m;
        public decimal Total
        {
            get
            {
                // Calcular el total como la suma del precio de todos los helados y toppings
                _total = _helados.Sum(h => h.TamanyoH.Precio);
                _total += _helados.Sum(h => h.ToppingsH.PrecioPlus);

                return _total;
            }
            set
            {
                OnPropertyChanged(nameof(Total));
            }
        }

        private ObservableCollection<Helado> _helados => _mainViewModel.helados;
        
        public ObservableCollection<Helado> Helados // Nombre que se usa en la vista --> {Binding miString}
        {
            get
            {
                return _helados;
            }
            
        }

        // Commands
        public ICommand BorrarHeladoCommand { get; }
        public ICommand PagarCommand { get; } 

        private InicioVM _mainViewModel;

        public PedidoVM(InicioVM mainViewModel)
        {
            _mainViewModel = mainViewModel;

            // Inicializa el comando de borrar, pasando el índice como parámetro
            BorrarHeladoCommand = new RelayCommand(
                parameter => borrarHeladoPedido(Convert.ToInt32(parameter))
            );


            PagarCommand = new PagarCommand(_mainViewModel.helados);

            _helados.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Total)); // Actualizar el total si la colección cambia
            };

            //helados = new ObservableCollection<Helado>();
            //Helado helado = new Helado(0, new Tipo(), new Tamanyo(), new Sabor(), new Topping());
            //helado.Id = 1;
            //helado.TipoH = new Tipo();
            //helado.TipoH.TipoNombre = "Nombre";
            //helado.TamanyoH = new Tamanyo();
            //helado.SaboresH = new Sabor();
            //Sabor sabor1 = new Sabor
            //{
            //    Id = 1,
            //    SaborNombre = "Chocolate",
            //    azucar = true
            //};

            //Sabor sabor2 = new Sabor
            //{
            //    Id = 2,
            //    SaborNombre = "Vainilla",
            //    azucar = false
            //};
            //helado.SaboresH = sabor1;
            //helados.Add(helado);
            //helados.Add(helado);
            //helados.Add(helado);
            //helados.Add(helado);
            //helados.Add(helado);
            //helados.Add(helado);
            //helados.Add(helado);
            //helados.Add(helado);
        }

        public void borrarHeladoPedido(int index)
        {
            // Validar que el índice sea válido antes de eliminar
            if (index >= 0 && index < _helados.Count)
            {
                _helados.RemoveAt(index);
                OnPropertyChanged(nameof(Total)); // Actualiza el total después de eliminar
            }
        }


    }


}
