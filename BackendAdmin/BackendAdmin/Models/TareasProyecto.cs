using System;
using System.Collections.Generic;

namespace BackendAdmin.Models
{
    public partial class TareasProyecto
    {
        public int IdTareaProyecto { get; set; }
        public int? IdTarea { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual Tarea? IdTareaNavigation { get; set; }
    }
}
