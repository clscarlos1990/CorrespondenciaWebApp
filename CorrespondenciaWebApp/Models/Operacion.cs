using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Operacion
    {
        public Operacion()
        {
            Auditoria = new HashSet<Auditorium>();
        }

        public int OperacionId { get; set; }
        public int ModuloId { get; set; }
        public int RolId { get; set; }
        public int TipoOperacionId { get; set; }

        public virtual Modulo Modulo { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual TipoOperacion TipoOperacion { get; set; }
        public virtual ICollection<Auditorium> Auditoria { get; set; }
    }
}
