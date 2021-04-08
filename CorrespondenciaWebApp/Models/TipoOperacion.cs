using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class TipoOperacion
    {
        public TipoOperacion()
        {
            Operacions = new HashSet<Operacion>();
        }

        public int TipoOperacionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
