using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Models;

namespace TPVproyecto.ViewModels
{
    public class ProductoVM : BaseVM
    {
        private string myVar;

        public string MiProducto // Nombre que se usa en la vista --> {Binding miString}
        {
            get { 
                return myVar;
            }
            set
            {
                myVar = value;
                OnPropertyChanged(nameof(MiProducto));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ProductoVM()
        {
            SubmitCommand = new BotonPruebaCommand();
        }
    }
}
