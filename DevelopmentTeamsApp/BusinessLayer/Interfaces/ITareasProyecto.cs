using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITareasProyecto
    {
        List<TareasProyecto> GetTareasProyectos();
        TareasProyecto GetTareasProyecto(int id);
        void AddTareasProyecto(TareasProyecto nuevaTareasProyecto);
        void UpdateTareasProyecto(TareasProyecto nuevaTareasProyecto);
        void DeleteTareasProyecto(int id);
    }
}
