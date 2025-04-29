using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Services;
using TPVproyecto.ViewModels;
using TPVproyecto.ViewModels.Admin;

namespace TPVproyecto.Commands.NavCommands
{
    public class NavCommand<TViewModel> : CommandBase
        where TViewModel : BaseVM // Para asegurarno s que TVIewModel  es de tipo BaseVM
    {
        // NavigationStore
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }

    }
}
