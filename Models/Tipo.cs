using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }
        public string NombreTipo { get; set; }

       
    }
}
