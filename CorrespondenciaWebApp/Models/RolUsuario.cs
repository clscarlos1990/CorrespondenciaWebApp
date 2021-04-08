#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class RolUsuario
    {
        public int RolUsuarioId { get; set; }
        public int RolId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
