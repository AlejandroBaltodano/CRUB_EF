using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CRUD_EF.UI.MVC.Models
{
    public class TelefonosModelMVC
    {
        public int idTelefono { get; set; }
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Debe de llenar el telefono")]
        [Display(Name = "Nombre completo")]
        public string Telefono { get; set; }
    }
}