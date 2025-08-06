using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Demo03.Data;
using Demo03.Models;

namespace Demo03.Pages.Categorias
{
    public class CreateModel : PageModel
    {
        private readonly Demo03.Data.Demo03Context _context;

        public CreateModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public categoria categoria { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
