using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Models;
using TPVproyecto.ViewModels;
using TPVproyecto.Views.Ventanas;

namespace TPVproyecto.Commands
{
    public class PagarSelectCommand : CommandBase
    {
        PagarWindow _pagarWindow;
        decimal _total;

        public PagarSelectCommand(decimal total) {
            _total = total;
        }

        public override void Execute(object? parameter)
        {
            if (_pagarWindow == null || !_pagarWindow.IsLoaded)
            {
                _pagarWindow = new PagarWindow(_total);
                _pagarWindow.Show();

            }
            else
            {
                _pagarWindow.Close();
            }
        }

        public decimal setTotal(decimal total)
        {
            _total = total;
            return _total;
        }
    }
}
