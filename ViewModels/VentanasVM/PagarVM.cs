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

        // Constructor
        public PagarVM() {
            
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
