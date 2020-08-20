using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_EF.UI.MVC.Controllers
{
    public class TelefonosController : Controller
    {
        // GET: Telefonos

        public ActionResult Index(int id)
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            List<Model.TelefonoModel> lalistaTelefonosPorPersona = context.laListaTelefenosPorPersona(id);


            return View(lalistaTelefonosPorPersona);
        }


        public ActionResult nuevoTelefono(int id)
        {
            return View(id);
        }
        public ActionResult nuevoTelefono(int id, Models.TelefonosModelMVC telefono)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AccesoADatos.Context context = new AccesoADatos.Context();
                    Model.TelefonoModel telefonoModel = new Model.TelefonoModel();
                    telefonoModel.idPersona = id;
                    telefonoModel.Telefono = telefono.Telefono;

                    context.insertarTelefonoPersona(telefonoModel);

                    return Redirect("~/Telefonos/Index/" + id);

                }
                return View(telefono);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


      
        }
    }
}