using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PImag.Data;
using PImag.Models;


namespace PImag.Pages
{
    public class SubirArchivoDbModel : PageModel
    {
        private readonly PImagDbContext _context; 
         public SubirArchivoDbModel(PImagDbContext context, 
            IConfiguration config)
        {
            _context = context;
            
        }
        [BindProperty]
        public SubirArchivoDb FileUpload { get; set; }
        public Archivo Archivo {get;set;}

        public string Result { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }
            using (var memoryStream = new MemoryStream())
            {
            await FileUpload.FormFile.CopyToAsync(memoryStream);

        // Upload the file if less than 2 MB
            if (memoryStream.Length < 2097152)
            {
                var file = new Archivo()
                {
                    nombre_imagen = FileUpload.FormFile.FileName,
                    tamaño=FileUpload.FormFile.Length,
                    UploadDT=DateTime.UtcNow,
                    image_file = memoryStream.ToArray()

                };

                _context.Archivo.Add(file);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError("Archivo", "El Archivo es demasiado largo");
            }
        }

        return Page();
    }
    public class SubirArchivoDb
    {
        [Required]
        [Display(Name="File")]
        public IFormFile FormFile { get; set; }

        
    }
}
}