using BusinessLayer.Interfaces;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Clases
{
    public class LogicaTarea : ITarea
    {
        private DBDevelopmentAppContext db;
        public LogicaTarea (DBDevelopmentAppContext db)
        {
            this.db = db;
        }
        public List<Tarea> GetTareas()
        {
            return db.Tareas.ToList();
        }

        public Tarea GetTarea(int id)
        {
            return db.Tareas.FirstOrDefault(t => t.IdTarea == id);
        }

        public void AddTarea(Tarea nuevaTarea)
        {
            db.Tareas.Add(nuevaTarea);
            db.SaveChanges();
        }

        public void UpdateTarea(Tarea nuevaTarea)
        {
            db.Tareas.Update(nuevaTarea);
            db.SaveChanges();
        }
        public void DeleteTarea(int id)
        {
            var tarea = db.Tareas.Find(id);
            if (tarea != null)
            {
                db.Tareas.Remove(tarea);
                db.SaveChanges();
            }
        }

    }
}
