using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Commands.NavCommands;
using TPVproyecto.Models;
using TPVproyecto.Services;
using TPVproyecto.ViewModels.Admin;
using TPVproyecto.ViewModels.PagPedidos;


namespace TPVproyecto.ViewModels
{
    public class InicioVM : BaseVM
    {
        public ElegirVM ElegirVM_Main { get; set; }
        public PedidoVM PedidoVM_Main { get; set; }
        public ObservableCollection<Helado> helados;
        
        private readonly NavigationStore _navigationStore;

        // Comandos
        public ICommand AdminCommand { get; set; }
        public ICommand CuentasCommand { get; set; }
        public ICommand SalirCommand { get; set; }


        // CONTRUCTOR
        public InicioVM(NavigationStore navigationStore) {

            _navigationStore = navigationStore;
            helados = new ObservableCollection<Helado>();
            // helados.Add(new Helado(0, new Tipo(), new Tamanyo(), sabor, new Topping()));
            ElegirVM_Main = new ElegirVM(this);
            PedidoVM_Main = new PedidoVM(this);
            
           
            ElegirVM_Main.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == "ToppingSeleccionado") // cuando se seleccione el Topping --> guarda el Helado la lista de helados
                {
                    Console.WriteLine("Helado guardado");
                    Console.WriteLine(helados);
                    // TODO: ElegirVM_Main.agregarHelado();
                }
            };

            AdminCommand = new NavCommand<AdminVM>(navigationStore, () => new AdminVM(navigationStore)); // empleo el objeto navigationStore
            CuentasCommand = new NavCommand<PedidosVM>(navigationStore, () => new PedidosVM(navigationStore, this));
        }

        public ObservableCollection<Helado> agregarHelado(Helado h)
        {
            if(h != null)
            {
                helados.Add(h);
            }

            return helados;
        }

        public Helado helado(int id) {
            
            Helado h = helados.First(h => h.Id == id);

            if(h != null)
            {
                helados.Remove(h);
                return h;
            }
            return null;
        }
    }
}
