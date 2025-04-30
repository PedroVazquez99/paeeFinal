using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Models.Pedido
{
    [Table("Lineas_Pedido")]
    public class LineaPedido
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Pedido")]
        public int ID_Pedido { get; set; }
        [ForeignKey("Tipo")]
        public int ID_Tipo { get; set; }
        [ForeignKey("Tamanyo")]
        public int ID_Tamanyo { get; set; }
        [ForeignKey("Sabor")]
        public int ID_Sabor { get; set; }
        [ForeignKey("Topping")]
        public int ID_Topping { get; set; }

        public decimal Subtotal { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Tamanyo Tamanyo { get; set; }
        public virtual Sabor Sabor { get; set; }
        public virtual Topping Topping { get; set; }

        // FALTA TOPPINGS
    }
}
