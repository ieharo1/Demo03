using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly Demo03.Data.Demo03Context _context;
        public string categorias { get; set; }
        public DeleteModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        [BindProperty]
        public producto producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            producto = await _context.producto.FirstOrDefaultAsync(m => m.id == id);
            var aux = _context.categoria.Where(c => c.id == producto.categoria).FirstOrDefault();
            categorias= aux.nombre;

            if (producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            producto = await _context.producto.FindAsync(id);

            if (producto != null)
            {
                _context.producto.Remove(producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
