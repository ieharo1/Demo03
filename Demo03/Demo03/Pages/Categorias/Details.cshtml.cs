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
    public class DetailsModel : PageModel
    {
        private readonly Demo03.Data.Demo03Context _context;

        public DetailsModel(Demo03.Data.Demo03Context context)
        {
            _context = context;
        }

        public categoria categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            categoria = await _context.categoria.FirstOrDefaultAsync(m => m.id == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
