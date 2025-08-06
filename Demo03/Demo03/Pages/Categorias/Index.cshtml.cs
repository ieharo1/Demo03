using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string searchstring { get; set; }
        private readonly Demo03.Data.Demo03Context _context;

        public IndexModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        public IList<categoria> categoria { get;set; }

        public async Task OnGetAsync()
        {
            var categorias = _context.categoria.Select(c => c);
            if (!string.IsNullOrEmpty(searchstring))
            {
                categorias = categorias.Where(c => c.nombre.Contains(searchstring));
            }
            categoria = await categorias.ToListAsync();
        }
    }
}
