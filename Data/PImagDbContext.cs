using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PImag.Models;

namespace PImag.Data
{
    public class PImagDbContext : DbContext
    {
        public PImagDbContext (DbContextOptions<PImagDbContext> options)
            : base(options)
        {
        }

        public DbSet<PImag.Models.Persona> Persona { get; set; }
        public DbSet<PImag.Models.Archivo> Archivo { get; set; }
    }
}
