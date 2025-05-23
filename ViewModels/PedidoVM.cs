﻿using System;
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
                _total = value; // Guarda el valor en `_total`
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
        public ICommand MesaSelectCommand { get; } 
        public ICommand PagarSelectCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        private InicioVM _mainViewModel;

        public PedidoVM(InicioVM mainViewModel)
        {
            _mainViewModel = mainViewModel;

            // Inicializa el comando de borrar, pasando el índice como parámetro
            BorrarHeladoCommand = new RelayCommand(
                parameter => borrarHeladoPedido(Convert.ToInt32(parameter))
            );


            MesaSelectCommand = new MesaSelectCommand(_mainViewModel.helados);
            PagarSelectCommand = new PagarSelectCommand(Total, mainViewModel.helados);
            ResetCommand = new RelayCommand(_ => ResetearLista());

            _helados.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Total)); // Actualizar el total si la colección cambia
            };

            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Total))
                {
                    PagarSelectCommand = new PagarSelectCommand(Total, mainViewModel.helados);
                    OnPropertyChanged(nameof(PagarSelectCommand)); // Notifica que el comando ha cambiado
                }
            };

            


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

        public void ResetearLista()
        {
            _helados.Clear();
            OnPropertyChanged(nameof(Helados));
            OnPropertyChanged(nameof(Total)); // Actualizar el total a 0
        }

    }


}
