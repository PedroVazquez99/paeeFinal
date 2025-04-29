using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TPVproyecto.ViewModels.OpcionesVM;

namespace TPVproyecto.Commands
{
    internal class OpcionCommand : CommandBase
    {
        private OpcionesVM _opcionVM;

        public OpcionCommand(OpcionesVM _opcionViewModel) {
        
            _opcionVM = _opcionViewModel;
        }

        public override void Execute(object? parameter)
        {
            switch (parameter)
            {
                case "Admin":
                    // si hace click en la vista de ADMIN
                    break;
                
            }
        }
    }
}
