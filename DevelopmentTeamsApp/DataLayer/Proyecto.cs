using System;
using System.Collections.Generic;

namespace DataLayer
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            PersonasProyectos = new HashSet<PersonasProyecto>();
            TareasProyectos = new HashSet<TareasProyecto>();
        }

        public int IdProyecto { get; set; }
        public string? NombreProyecto { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<PersonasProyecto> PersonasProyectos { get; set; }
        public virtual ICollection<TareasProyecto> TareasProyectos { get; set; }
    }
}
