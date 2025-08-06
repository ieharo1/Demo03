using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03.Models
{
    public class categoria
    {
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
    }
}
