using BusinessLayer.Interfaces;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Clases
{
    public class LogicaPersona : IPersona
    {
        private DBDevelopmentAppContext db;
        public LogicaPersona(DBDevelopmentAppContext db)
        {
            this.db = db;
        }
        public List<Persona> GetPersonas()
        {
            return db.Personas.ToList();
        }

        public Persona GetPersona(int id)
        {
            return db.Personas.FirstOrDefault(t => t.IdPersona == id);
        }

        public void AddPersona(Persona nuevaPersona)
        {
            db.Personas.Add(nuevaPersona);
            db.SaveChanges();
        }

        public void UpdatePersona(Persona nuevaPersona)
        {
            db.Personas.Update(nuevaPersona);
            db.SaveChanges();
        }
        public void DeletePersona(int id)
        {
            var persona = db.Personas.Find(id);
            if (persona != null)
            {
                db.Personas.Remove(persona);
                db.SaveChanges();
            }
        }
    }
}
