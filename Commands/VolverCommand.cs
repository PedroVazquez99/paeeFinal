using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Services;

namespace TPVproyecto.Commands
{
    public class VolverCommand : CommandBase
    {

        NavigationStore _navigationStore;

        public VolverCommand(NavigationStore navigationStore) {
            _navigationStore = navigationStore; 
        }

        public override void Execute(object? parameter)
        {
             _navigationStore.NavigateBack();
        }
    }
}
