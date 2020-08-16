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

    }
}
