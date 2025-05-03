using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Helado> _helados;

        public PagarSelectCommand(decimal total, ObservableCollection<Helado> helados) {
            _total = total;
            _helados = helados;
        }

        public override void Execute(object? parameter)
        {
            if (_pagarWindow == null || !_pagarWindow.IsLoaded)
            {
                _pagarWindow = new PagarWindow(_total, _helados);
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
