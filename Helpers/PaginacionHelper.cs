using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Models;

namespace TPVproyecto.Helpers
{
    public class PaginacionHelper<T>
    {
        private IEnumerable<T> _items;
        private int _itemsPorPagina;

        public int ActualPagina { get; private set; }
        public int TotalPages => (int)Math.Ceiling((double)_items.Count() / _itemsPorPagina);

        public PaginacionHelper(IEnumerable<T> items, int itemsPorPagina)
        {
            _items = items;
            _itemsPorPagina = itemsPorPagina;
            ActualPagina = 1;
            
        }

        public IEnumerable<T> getPaginaActualElementos()
        {
            return _items
                .Skip((ActualPagina - 1) * _itemsPorPagina)
                .Take(_itemsPorPagina);
        }

        public void siguientePag()
        {
            if (ActualPagina < TotalPages)
                ActualPagina++;
        }

        public void siguientePaga(IEnumerable<Tipo> x)
        {
            if (ActualPagina < TotalPages)
                ActualPagina++;
        }

        public void anteriorPag()
        {
            if (ActualPagina > 1)
                ActualPagina--;
        }

        public void irPagina(int page)
        {
            if (page >= 1 && page <= TotalPages)
                ActualPagina = page;
        }
    }

}



//USO
//        // Inicializa la colección principal
//        AllItems = new ObservableCollection<string>(
//            Enumerable.Range(1, 100).Select(x => $"Item {x}")
//        );

//// Configura el helper de paginación
//_paginationHelper = new PaginationHelper<string>(AllItems, 10);

//// Inicializa la colección visible
//CurrentPageItems = new ObservableCollection<string>(_paginationHelper.GetCurrentPageItems());

//// Configura comandos
//NextPageCommand = new RelayCommand(_ => GoToNextPage(), _ => CanGoToNextPage());
//PreviousPageCommand = new RelayCommand(_ => GoToPreviousPage(), _ => CanGoToPreviousPage());
