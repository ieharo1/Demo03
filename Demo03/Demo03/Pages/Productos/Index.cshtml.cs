using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo03.Pages.Productos
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string buscar { get; set; }
        [BindProperty(SupportsGet = true)]
        public string buscarcategoria { get; set; }
        public int idcategoria { get; set; }
        public List<string> nombrescategoria { get; set; }
        public SelectList buscarcategorias { get; set; }
        private readonly Demo03.Data.Demo03Context _context;

        public IndexModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        public IList<producto> producto { get;set; }

        public async Task OnGetAsync()
        {
            nombrescategoria = new List<string>();
            var productos = _context.producto.Select(c => c);
            var aux2 = _context.categoria.Select(c => c.nombre);

            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(c => c.nombre.Contains(buscar));
            }
            if (!string.IsNullOrEmpty(buscarcategoria))
            {
                var aux3 = _context.categoria.Where(c => c.nombre == buscarcategoria).FirstOrDefault();
                productos = productos.Where(c => c.categoria == aux3.id);
            }

            buscarcategorias = new SelectList(await aux2.Distinct().ToListAsync());
            producto = await productos.ToListAsync();

            foreach (var producto in productos)
            {
                int auxId = producto.categoria;
                var aux = _context.categoria.Where(c => c.id == auxId).FirstOrDefault();
                if (!string.IsNullOrEmpty(aux.nombre))
                {
                    nombrescategoria.Add(aux.nombre);
                }
            }
        }
    }
}
