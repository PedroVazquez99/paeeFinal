using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;
using TPVproyecto.Services.Pedidos;

namespace TPVproyecto.ViewModels.VentanasVM
{
    internal class PagarVM : BaseVM
    {

        ObservableCollection<Helado> _helados;

        private string _textoPad = "0.00";
        public string TextoPad
        {
            get { return _textoPad; }
            set
            {
                _textoPad = value;
                OnPropertyChanged(nameof(TextoPad));
                OnPropertyChanged(nameof(Cambio));

            }
        }

        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        private decimal _cambio = 0.00m;
        public decimal Cambio
        {
            get
            {
                // Calcular el cambio como la suma del precio de todos los helados y toppings
                _cambio = Convert.ToDecimal(_textoPad) - _total;

                return _cambio;
            }
            set
            {
                _cambio = value; // 🔄 Guarda el valor en `_cambio`
                OnPropertyChanged(nameof(Cambio));
            }
        }

        // COMANDOS
        public ICommand PagoCash { get; }
        public ICommand PagoTarjeta { get; }
        public Action CerrarVentanaAction { get; set; } // Accion para cerrar la ventana

        // SERVICIOS
        private PedidosService _pedidosService;

        // CONTRUCTOR
        public PagarVM(decimal total, ObservableCollection<Helado> helados) {
            _total = total;
            _helados = helados;

            _pedidosService = new PedidosService();

            PagoCash = new RelayCommand(
                canExecute: PuedePagoCash,
                execute: EjecutarPagoCash
            );
        }


        public bool PuedePagoCash(object parameter)
        {
            if(_textoPad != null && _textoPad.Length > 0)
            {
                return true;
            }
            return false;
        }

        public void EjecutarPagoCash(object parameter)
        {
            if(_cambio >= 0)
            {
                _pedidosService.CompletarPedido(2);
                _helados.Clear();
                CerrarVentanaAction.Invoke(); // Cerramos la ventana

            }
        }



        public void pagoLlevar()
        {
            try
            {
                Console.WriteLine(_textoPad);
            }
            catch
            {
                MessageBox.Show("Hubo un error en el pago");
            }
        }
    }
}
