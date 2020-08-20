using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_EF.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            List<Model.PersonaModel> lalistaPersonas = context.laListaPersonas();

            return View(lalistaPersonas);
        }
        //metodo nueva persona vista
        public ActionResult nuevaPersona()
        {

            return View();
        }
        //metodo nuevapersona que recibe los datos de la pagina y los inserta a base de datos, usamos polimorfismo
        [HttpPost]
        public ActionResult nuevaPersona(Models.PersonaModelMVC nuevapersona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AccesoADatos.Context context = new AccesoADatos.Context();
                    Model.PersonaModel persona = new Model.PersonaModel();
                    persona.Nombre = nuevapersona.Nombre;
                    persona.Cedula = nuevapersona.Cedula;
                    persona.FechaNacimiento = nuevapersona.FechaNacimiento;

                    context.insertarPersona(persona);

                    //return Redirect("/");
                    return Redirect("/");

                }
                return View(nuevapersona);

               

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            
            
        }

        public ActionResult editarPersona(int id)
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            var persona = context.obtenerPersonaPorid(id);
            Models.PersonaModelMVC personaObtenida = new Models.PersonaModelMVC();

            personaObtenida.idPersona = persona.idPersona;
            personaObtenida.Nombre = persona.Nombre;
            personaObtenida.Cedula = persona.Cedula;
            personaObtenida.FechaNacimiento = persona.FechaNacimiento;


            return View(personaObtenida);
        }
        [HttpPost]
        public ActionResult editarPersona(Models.PersonaModelMVC personaEditar) {


            try
            {
                if (ModelState.IsValid)
                {
                    AccesoADatos.Context context = new AccesoADatos.Context();
                    Model.PersonaModel persona = new Model.PersonaModel();
                    persona.Nombre = personaEditar.Nombre;
                    persona.Cedula = personaEditar.Cedula;
                    persona.FechaNacimiento = personaEditar.FechaNacimiento;

                    context.editarPersona(personaEditar.idPersona, persona);

                    return Redirect("/");

                }
                return View(personaEditar);


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        
        
        }


        [HttpGet]
        public ActionResult eliminarPersona(int id)
        {


            try
            {
                
                AccesoADatos.Context context = new AccesoADatos.Context();

                context.eliminarPersona(id);

                    return Redirect("/");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}