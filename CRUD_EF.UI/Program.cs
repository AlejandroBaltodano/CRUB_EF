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
            mostrarDatosTelefono();
            Console.ReadLine();
            eliminarTelefono();
            Console.ReadLine();
            mostrarDatosTelefono();
            Console.ReadLine();
            



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

        public  static void mostrarDatosTelefono()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            List<Model.TelefonoModel> listaTelefonosPersona = context.laListaTelefenosPorPersona(4);
            foreach (var item in listaTelefonosPersona)
            {

                Console.WriteLine(item.idPersona+" "+item.Nombre+" "+item.Telefono);
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

        public static void insertarTelefono()
        {

            AccesoADatos.Context context = new AccesoADatos.Context();
            Model.TelefonoModel telefonoModel = new Model.TelefonoModel();
            telefonoModel.idPersona = 4;
            telefonoModel.Telefono = "1234567891";

            context.insertarTelefonoPersona(telefonoModel);

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

        public static void editarTelefono()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            Model.TelefonoModel telefonoModel = new Model.TelefonoModel();
            telefonoModel.idPersona = 4;
            telefonoModel.Telefono = "60213478";

            context.editarTelefonoPersona(8, telefonoModel);
        }

        public static void eliminarPersona()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            context.eliminarPersona(7);
        }

        public static void eliminarTelefono()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            context.eliminarTelefonoPersona(9);

        }

    }
}
