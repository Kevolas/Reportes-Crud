using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD1.Models
{
    public class ReporteModel
    {

        public int id {get; set;}

        [Required]
        public string  Proveedor { get; set; }


        [Required]
        public int Monto { get; set; }

        [Required]
        public string Moneda { get; set; }

        [Required]
        public string Fecha { get; set; }

        public string Comentario { get; set; }
    }
}
