using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EF.Model
{
    class TelefonoModel
    {
        public int idTelefono { get; set; }
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }


    }
}
