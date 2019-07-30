using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud_Alumnos.Models
{
    public class AlumnoCE // es como un AX "clase auxiliar"
    {
     
        public int AlumnoId { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Ingrese Edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Ingrese Sexo")]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Ingrese Ciudad")] 
        public int CiudadId { get; set; }
        //public string Nombre { get; set; }

        //public DateTime FechaAlta { get; set; }

        //public int Estado { get; set; }
    }

    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno // si es como un ax
    {
        //public int Estado { get; set; }
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}