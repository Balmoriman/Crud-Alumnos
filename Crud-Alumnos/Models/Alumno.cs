//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crud_Alumnos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int CiudadId { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
    }
}
