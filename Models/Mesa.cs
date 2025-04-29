using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public string NombreMesa { get; set; }
        public bool IsActivo { get; set; }

        public Mesa()
        {
            IsActivo = true;  // Valor predeterminado para isActivo
        }

    }


}
