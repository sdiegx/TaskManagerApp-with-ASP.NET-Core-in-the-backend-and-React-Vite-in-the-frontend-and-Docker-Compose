using BusinessLayer.Interfaces;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Clases
{
    public class LogicaProyecto : IProyecto
    {
        private DBDevelopmentAppContext db;
        public LogicaProyecto(DBDevelopmentAppContext db)
        {
            this.db = db;
        }
        public List<Proyecto> GetProyectos()
        {
            return db.Proyectos.ToList();
        }

        public Proyecto GetProyecto(int id)
        {
            return db.Proyectos.FirstOrDefault(t => t.IdProyecto == id);
        }

        public void AddProyecto(Proyecto nuevoProyecto)
        {
            db.Proyectos.Add(nuevoProyecto);
            db.SaveChanges();
        }

        public void UpdateProyecto(Proyecto nuevoProyecto)
        {
            db.Proyectos.Update(nuevoProyecto);
            db.SaveChanges();
        }
        public void DeleteProyecto(int id)
        {
            var proyecto = db.Proyectos.Find(id);
            if (proyecto != null)
            {
                db.Proyectos.Remove(proyecto);
                db.SaveChanges();
            }
        }
    }
}
