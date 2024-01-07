using System;
using System.Collections.Generic;

namespace BackendAdmin.Models
{
    public partial class PersonasProyecto
    {
        public int IdPersonaProyecto { get; set; }
        public int? IdPersona { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
