using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TPVproyecto.Models;
using TPVproyecto.ViewModels;

namespace TPVproyecto.Commands
{
    internal class ElegirCommand : CommandBase
    {
        private readonly ElegirVM _elegirVM;
        

        public ElegirCommand(ElegirVM viewModel)
        {
            _elegirVM = viewModel;
            
        }

        public override void Execute(object? parameter)
        {
            switch (parameter)
            {
                case Tipo tipo:

                    // base.CanExecute(true);
                    _elegirVM.SeleccionarElemento(tipo);
                    break;

                case Tamanyo tamanyo:
                    _elegirVM.SeleccionarElemento(tamanyo);
                    break;

                case Sabor sabor:
                    _elegirVM.SeleccionarElemento(sabor);
                    break;
                case Topping topping:
                    _elegirVM.SeleccionarElemento(topping);
                    break;

            }
        }

    }
}
