using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03.Models
{
    public class producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal pvp { get; set; }
        public int stock { get; set; }
        public int categoria { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_elaboracion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_caducidad { get; set; }
        public string descripcion { get; set; }
    }
}
