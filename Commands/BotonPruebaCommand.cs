﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPVproyecto.Commands
{
    internal class BotonPruebaCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MessageBox.Show("¿Desea continuar?", "Confirmación", MessageBoxButton.YesNo);

        }
    }
}
