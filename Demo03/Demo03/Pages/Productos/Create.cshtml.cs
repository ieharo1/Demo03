using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly Demo03.Data.Demo03Context _context;
        [BindProperty(SupportsGet = true)]
        public string selecciona { get; set; }
        public  SelectList listacategoria { get; set; }
        public CreateModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var aux = _context.categoria.Select(c => c.nombre);
            listacategoria = new SelectList(aux.ToList());
            return Page();

        }

        [BindProperty]
        public producto producto { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var categoria = _context.categoria.Where(c => c.nombre.Equals(selecciona)).FirstOrDefault();
            producto.categoria = categoria.id;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.producto.Add(producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
