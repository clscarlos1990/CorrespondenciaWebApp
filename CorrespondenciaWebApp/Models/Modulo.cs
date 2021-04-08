using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Operacions = new HashSet<Operacion>();
        }

        public int ModuloId { get; set; }
        public string NombreModulo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
