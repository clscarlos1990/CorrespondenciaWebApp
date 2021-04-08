using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Operacions = new HashSet<Operacion>();
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public int RolId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Operacion> Operacions { get; set; }
        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
