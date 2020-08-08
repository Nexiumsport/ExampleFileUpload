using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PImag.Data;
using PImag.Models;

namespace PImag.Pages.Personas
{
    public class DetailsModel : PageModel
    {
        private readonly PImag.Data.PImagDbContext _context;

        public DetailsModel(PImag.Data.PImagDbContext context)
        {
            _context = context;
        }

        public Persona Persona { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persona = await _context.Persona
                .Include(p => p.Archivo).FirstOrDefaultAsync(m => m.ID == id);

            if (Persona == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
