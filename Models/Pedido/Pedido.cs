using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Models.Pedido
{
    public class Pedido
    {
        [Key]
        public int ID_Pedido { get; set; }

        [ForeignKey("Mesa")]
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool IsPagado { get; set; }

        // Nueva propiedad para la relación con la Mesa
        public virtual Mesa Mesa { get; set; }     // Objeto de tipo Mesa

        public virtual List<LineaPedido> LineasPedido { get; set; }
    }
}
