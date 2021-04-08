using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Auditoria = new HashSet<Auditorium>();
            Comunicacions = new HashSet<Comunicacion>();
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public short Estado { get; set; }

        public virtual ICollection<Auditorium> Auditoria { get; set; }
        public virtual ICollection<Comunicacion> Comunicacions { get; set; }
        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
