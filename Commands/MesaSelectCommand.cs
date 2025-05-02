using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPVproyecto.Models;
using TPVproyecto.Services;
using TPVproyecto.Views.Ventanas;

namespace TPVproyecto.Commands
{
    public class MesaSelectCommand : CommandBase
    {
        //private HeladoService heladoS = new HeladoService();
        private MesaWindow _mesaWindow;
        private ObservableCollection<Helado> _helados;

        public MesaSelectCommand(ObservableCollection<Helado> helados)
        {
            _helados = helados;
        }

        public override void Execute(object? parameter)
        {
            if (_mesaWindow == null || !_mesaWindow.IsLoaded)
            {
                _mesaWindow = new MesaWindow(_helados);
                _mesaWindow.Show();
                
            }else
            {
                _mesaWindow.Close();
            }
        }
    }
}
