using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IProyecto
    {
        List<Proyecto> GetProyectos();
        Proyecto GetProyecto(int id);
        void AddProyecto(Proyecto nuevaProyecto);
        void UpdateProyecto(Proyecto nuevaProyecto);
        void DeleteProyecto(int id);
    }
}
