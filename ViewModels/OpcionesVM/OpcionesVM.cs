using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;

namespace TPVproyecto.ViewModels.OpcionesVM
{
    public class OpcionesVM : BaseVM
    {
        
        public ICommand opcionCommand { get; set; }

        public OpcionesVM() {
            // opcionCommand = new OpcionCommand();
        }



        
    }
}
