using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITarea
    {
        List<Tarea> GetTareas();
        Tarea GetTarea(int id);
        void AddTarea(Tarea nuevaTarea);
        void UpdateTarea(Tarea nuevaTarea); 
        void DeleteTarea(int id);
    }
}
