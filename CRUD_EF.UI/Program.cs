using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EF.UI
{
    class Program
    {
     


        static void Main(string[] args)
        {
            mostrarDatos();
            Console.ReadLine();
            editarPersona();
            Console.ReadLine();
            mostrarDatos();



        }
        public static void mostrarDatos()
        {
            AccesoADatos.Context contexto = new AccesoADatos.Context();

            List<Model.PersonaModel> lista = contexto.laListaPersonas();
            foreach (var item in lista)
            {
                Console.WriteLine(item.idPersona + " " + item.Nombre + " " + item.Cedula + " " + item.FechaNacimiento.Value.ToString("dd/MM/yyyy"));
                Console.ReadLine();
            }
        }

        public static void insertarPerosna()
        {

            AccesoADatos.Context context = new AccesoADatos.Context();
            Model.PersonaModel lapersona = new Model.PersonaModel();
            lapersona.Nombre = "Prueba1";
            lapersona.Cedula = "Prueba1";
            lapersona.FechaNacimiento =  DateTime.Now;

            context.insertarPersona(lapersona);

        }

        public static void editarPersona()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            Model.PersonaModel lapersona = new Model.PersonaModel();
            lapersona.Nombre = "Sophia Alejandra Escoto Machado";
            lapersona.Cedula = "101230456";
            lapersona.FechaNacimiento = DateTime.Now;

            context.editarPersona(2,lapersona);


        }

        public static void eliminarPersona()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            context.eliminarPersona(7);
        }

    }
}
