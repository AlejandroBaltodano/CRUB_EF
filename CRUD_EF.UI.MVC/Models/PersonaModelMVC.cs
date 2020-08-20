using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD_EF.UI.MVC.Models
{
    public class PersonaModelMVC
    {
        public  int idPersona { get; set; }
        [Required(ErrorMessage ="Debe de llenar el campo nombre completo")]
        [Display(Name ="Nombre completo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Debe de llenar el campo identificacion")]
        [Display(Name = "Identificacion")]
        public string Cedula { get; set; }
        
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }
    }
}