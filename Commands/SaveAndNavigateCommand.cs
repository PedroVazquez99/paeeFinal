using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.ViewModels;

namespace TPVproyecto.Commands
{
    public class SaveAndNavigateCommand : CommandBase
    {
        private readonly ElegirVM _viewModel;

        public SaveAndNavigateCommand(ElegirVM viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Console.WriteLine("Llega");
        }
    }
}
