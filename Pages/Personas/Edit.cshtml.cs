using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PImag.Data;
using PImag.Models;

namespace PImag.Pages.Personas
{
    public class EditModel : PageModel
    {
        private readonly PImag.Data.PImagDbContext _context;

        public EditModel(PImag.Data.PImagDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["archivoID"] = new SelectList(_context.Set<Archivo>(), "ID", "ID");
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

            _context.Attach(Persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(Persona.ID))
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

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.ID == id);
        }
    }
}
