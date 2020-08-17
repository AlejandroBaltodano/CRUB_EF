using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CRUD_EF.Model;

namespace CRUD_EF.AccesoADatos
{
    public class Context
    {
        public List<PersonaModel> laListaPersonas()
        {
            List<PersonaModel> listaPersonas;
            using(CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {

                listaPersonas = (from d in db.Persona
                                 select new PersonaModel
                                 {
                                     idPersona = d.idPersona,
                                     Nombre = d.Nombre,
                                     Cedula = d.Cedula,
                                     FechaNacimiento = d.FechaNacimiento,

                                 }).ToList();

            }
                return listaPersonas;

        }//fin lista de datos


        public void insertarPersona(PersonaModel nuevapersona)
        {
            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {
                Persona persona = new Persona();
                persona.Nombre = nuevapersona.Nombre;
                persona.Cedula = nuevapersona.Cedula;
                persona.FechaNacimiento = nuevapersona.FechaNacimiento;

                db.Persona.Add(persona);
                db.Entry(persona).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

            }

        }

        public Persona obtenerPersonaPorid(int id)
        {
            Persona lapersona = new Persona();
            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {

             lapersona = db.Persona.Find(id);
               


            }

            return lapersona;

        }


        public void editarPersona(int id, PersonaModel editarPersona)
        {
            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {

                var Newpersona = obtenerPersonaPorid(id);

                Newpersona.Nombre = editarPersona.Nombre;
                Newpersona.Cedula = editarPersona.Cedula;
                Newpersona.FechaNacimiento = editarPersona.FechaNacimiento;

                db.Entry(Newpersona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void eliminarPersona(int id)
        {
            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {
                //Persona eliminarPersona = db.Persona.Where(d => d.Nombre == "Gabriela  Reyes Baltodano rrrrrrr").First(); utilizando where
                Persona eliminarPersona = db.Persona.Find(id);
                db.Persona.Remove(eliminarPersona);
                db.SaveChanges();

            }

        }



        //desde aqui empiezan los metodos para crud de telefonos

     public List<TelefonoModel> laListaTelefenosPorPersona(int idPersona)
        {
            List<TelefonoModel> listaTelefonosPersona;

            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {
                listaTelefonosPersona = (from t in db.Telefono
                         join p in db.Persona on t.idPersona equals p.idPersona
                         where t.idPersona == idPersona
                         select new TelefonoModel
                         {
                             idTelefono = t.idTelefono,
                             idPersona = t.idPersona,
                             Nombre = p.Nombre,
                             Cedula = p.Cedula,
                             Telefono = t.Telefono1,

                         }).ToList();

                return listaTelefonosPersona;
            }

        }

        public void insertarTelefonoPersona(TelefonoModel telefonoModel)
        {
            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities()) {

                Telefono telefono = new Telefono();
                telefono.idPersona = telefonoModel.idPersona;
                telefono.Telefono1 = telefonoModel.Telefono;

                db.Telefono.Add(telefono);
                db.Entry(telefono).State = EntityState.Added;
                db.SaveChanges();
            
            
            
            }

        }

        public Telefono obtenerTelefonoporIdTelefono(int idTelefono)
        {

            Telefono telefono;
            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {
                telefono = db.Telefono.Find(idTelefono);



            }

            return telefono;

        }

        

        public void editarTelefonoPersona(int idTelefono, TelefonoModel telefono)
        {

            using(CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {
                var newTelefono = obtenerTelefonoporIdTelefono(idTelefono);
                newTelefono.idPersona = telefono.idPersona;
                newTelefono.Telefono1 = telefono.Telefono;

                db.Entry(newTelefono).State = EntityState.Modified;
                db.SaveChanges();

            }

        }

        public void eliminarTelefonoPersona(int idTelefono)
        {

            using (CRUBPersonaEFEntities db = new CRUBPersonaEFEntities())
            {
                var oldTelefono = db.Telefono.Find(idTelefono);

                db.Telefono.Remove(oldTelefono);
                db.SaveChanges();

            }
        }
        


    }
}
