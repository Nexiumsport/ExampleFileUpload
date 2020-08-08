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
    public class IndexModel : PageModel
    {
        private readonly PImag.Data.PImagDbContext _context;

        public IndexModel(PImag.Data.PImagDbContext context)
        {
            _context = context;
        }

        public IList<Persona> Persona { get;set; }

        public async Task OnGetAsync()
        {
            Persona = await _context.Persona
                .Include(p => p.Archivo).ToListAsync();
        }
    }
}
