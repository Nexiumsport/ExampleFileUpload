using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PImag.Data;
using PImag.Models;

namespace PImag.Pages.Archivos
{
    public class IndexModel : PageModel
    {
        private readonly PImag.Data.PImagDbContext _context;

        public IndexModel(PImag.Data.PImagDbContext context)
        {
            _context = context;
        }

        public IList<Archivo> Archivo { get;set; }
        

        public async Task OnGetAsync()
        {
            Archivo = await _context.Archivo           
            .ToListAsync();
        }
    }
}