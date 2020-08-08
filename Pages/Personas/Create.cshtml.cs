using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PImag.Data;
using PImag.Models;

namespace PImag.Pages.Personas
{
    public class CreateModel : PageModel
    {
        private readonly PImag.Data.PImagDbContext _context;

        public CreateModel(PImag.Data.PImagDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["archivoID"] = new SelectList(_context.Set<Archivo>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Persona Persona { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Persona.Add(Persona);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
