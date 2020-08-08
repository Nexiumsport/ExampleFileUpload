using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PImag.Models
{
    public class Persona
    {
        public int ID {get;set;}
        [Required]
        //StringLength significa Min. y max. Longitud de caracteres permitidos en un campo de datos
        [StringLength(15, ErrorMessage = "Este campo no puede excedes de 15 caracteres")]
        [Display(Name = "Nombre")]
        public string nombre {get;set;}
        [Required]
        //MaxLength significa Max. longitud de matriz o datos de cadena permitidos
        [MaxLength(20, ErrorMessage = "Este campo no pueder exceder de 20 caracteres")]
        [Display(Name = "Apellido")]
        public string apellido {get;set;}
        [Required]
        [Display(Name = "Profesion")]
        [StringLength(25)]
        public string profesion {get;set;}
        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nacimiento {get;set;} 

        //Propiedades de Navegacion Dependientes
        [Display(Name = "Archivo")]
        public int? archivoID {get;set;}
        public Archivo Archivo {get;set;}
        //
        //Campos Calculados
        //Nombre + Apellido
        [NotMapped]
        [Display(Name = "Nombres")]
        public string nombre_apellido 
        {
            get
            {
                return nombre + " " + apellido;
            }
        }
        //Primera Letra Nombre + . + Apellido
        [NotMapped]
        [Display(Name = "Abreviacion")]
        public string nombre_corto 
        {
            get
            {
                return nombre[0] + "." + apellido;
            }
        }
        //Edad
        [NotMapped]
        [Display(Name = "Edad")]
        public string edad
        {
            get
            {
                int edad = DateTime.Today.Year - fecha_nacimiento.Year;
                string years = " años";
                //Cuando el mes es menor le restamos un año directamente
                
                if (DateTime.Today.Month < fecha_nacimiento.Month)
                 {
                    --edad;                
                 }
                 //Sino validamos el mes y el dia actual con la fecha de nacimiento               
                else if (DateTime.Today.Month == fecha_nacimiento.Month && DateTime.Today.Day < fecha_nacimiento.Day)
                    {
                    --edad;
                    }
                    //Concatencacion
                    string edad_year = string.Concat(edad, years);
                    return edad_year;
             }
        } 



    }
}