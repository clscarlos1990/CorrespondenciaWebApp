#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Auditorium
    {
        public int AuditoriaId { get; set; }
        public string Tabla { get; set; }
        public int OperacionId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Operacion Operacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
