using BusinessLayer.Interfaces;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Clases
{
    public class LogicaTareasProyecto : ITareasProyecto
    {
        private DBDevelopmentAppContext db;
        public LogicaTareasProyecto(DBDevelopmentAppContext db)
        {
            this.db = db;
        }
        public List<TareasProyecto> GetTareasProyectos()
        {
            return db.TareasProyectos.ToList();
        }

        public TareasProyecto GetTareasProyecto(int id)
        {
            return db.TareasProyectos.FirstOrDefault(t => t.IdTareaProyecto == id);
        }

        public void AddTareasProyecto(TareasProyecto nuevaTareasProyecto)
        {
            db.TareasProyectos.Add(nuevaTareasProyecto);
            db.SaveChanges();
        }

        public void UpdateTareasProyecto(TareasProyecto nuevaTareasProyecto)
        {
            db.TareasProyectos.Update(nuevaTareasProyecto);
            db.SaveChanges();
        }
        public void DeleteTareasProyecto(int id)
        {
            var tareasProyecto = db.TareasProyectos.Find(id);
            if (tareasProyecto != null)
            {
                db.TareasProyectos.Remove(tareasProyecto);
                db.SaveChanges();
            }
        }
    }
}
