using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly Demo03.Data.Demo03Context _context;
        public SelectList listacategoria { get; set; }
        [BindProperty(SupportsGet = true)]
        public string selecciona { get; set; }

        public EditModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        [BindProperty]
        public producto producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var aux = _context.categoria.Select(c => c.nombre);
            listacategoria = new SelectList(await aux.ToListAsync());
            if (id == null)
            {
                return NotFound();
            }

            producto = await _context.producto.FirstOrDefaultAsync(m => m.id == id);

            if (producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var categoria = _context.categoria.Where(c => c.nombre.Equals(selecciona)).FirstOrDefault();
            producto.categoria = categoria.id;
            _context.Attach(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productoExists(producto.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool productoExists(int id)
        {
            return _context.producto.Any(e => e.id == id);
        }
    }
}
