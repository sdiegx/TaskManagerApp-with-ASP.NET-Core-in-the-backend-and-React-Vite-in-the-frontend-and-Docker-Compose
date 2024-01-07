using System;
using System.Collections.Generic;

namespace DataLayer
{
    public partial class Persona
    {
        public Persona()
        {
            PersonasProyectos = new HashSet<PersonasProyecto>();
            Tareas = new HashSet<Tarea>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<PersonasProyecto> PersonasProyectos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
