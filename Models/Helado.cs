using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Models
{
    public class Helado
    {
        public int Id { get; set; }
        public Tipo TipoH { get; set; }
        public Tamanyo TamanyoH { get; set; }
        public Sabor SaboresH {  get; set; }
        public Topping ToppingsH { get; set; }

        public Helado(int _id, Tipo _tipoH, Tamanyo _tamanyoH, Sabor _saboresH, Topping _toppingsH) {
            Id = _id;
            TipoH = _tipoH;
            SaboresH = _saboresH;
            ToppingsH = _toppingsH;
        }

        public Helado() { }

    }
}
