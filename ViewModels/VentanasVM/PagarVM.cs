using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPVproyecto.ViewModels.VentanasVM
{
    internal class PagarVM : BaseVM
    {
        private string _textoPad = "";
        public string TextoPad
        {
            get { return _textoPad; }
            set
            {
                _textoPad = value;
                OnPropertyChanged(nameof(TextoPad));
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

        // Constructor
        public PagarVM(decimal total) {
            _total = total;
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
