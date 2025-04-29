using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TPVproyecto.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        // Activar o desativar el boton
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        // Cuando se pulsa, lo que se ejecuta
        public abstract void Execute(object? parameter);


        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
