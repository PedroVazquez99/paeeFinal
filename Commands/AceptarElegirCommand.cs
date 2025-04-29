using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPVproyecto.Models;
using TPVproyecto.Services;
using TPVproyecto.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace TPVproyecto.Commands
{
    class AceptarElegirCommand : CommandBase
    {
        private readonly InicioVM _mainViewModel;
        
        Helado helado = null;

        public AceptarElegirCommand(InicioVM mainViewModel, Tipo tipo) {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                helado = new Helado(12, new Tipo(), new Tamanyo(), new Sabor(), new Topping());
                _mainViewModel.agregarHelado(helado);
                
            }
            catch{ 
            
                MessageBox.Show("Se ha producido un error en la seleccion de helados");
            
            }

            // System.Diagnostics.Debug.WriteLine($"Recibido: {parameter}");
        }

        public override bool CanExecute(object parameter) {
            Console.WriteLine(parameter);
            return true;
        }
    }
}
