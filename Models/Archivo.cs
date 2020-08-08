using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PImag.Models
{
    public class Archivo
    {
        public int ID {get;set;}
        [Display(Name = "Nombre de Arvhivo")]
        public string nombre_imagen {get;set;}
        [Display(Name = "Tamaño (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public long tamaño { get; set; }
        [Display(Name = "Subido(UTC)")]
        [DisplayFormat(DataFormatString = "{0:G}")]
        public DateTime UploadDT { get; set; }
        
        [Display(Name = "Imagen")]
        public byte[] image_file {get;set;}
        //control + ?/ al lado del Shift izquiero comenta linea
        public ICollection<Persona> Personas {get;set;}
        
    }
}