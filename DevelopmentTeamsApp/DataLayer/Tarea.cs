using System;
using System.Collections.Generic;

namespace DataLayer
{
    public partial class Tarea
    {
        public Tarea()
        {
            TareasProyectos = new HashSet<TareasProyecto>();
        }

        public int IdTarea { get; set; }
        public string? NombreTarea { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public int? Minutos { get; set; }
        public int? Horas { get; set; }
        public int? IdPersona { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual ICollection<TareasProyecto> TareasProyectos { get; set; }
    }
}
