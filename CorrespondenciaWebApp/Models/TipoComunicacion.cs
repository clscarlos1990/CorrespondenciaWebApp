using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class TipoComunicacion
    {
        public TipoComunicacion()
        {
            Comunicacions = new HashSet<Comunicacion>();
        }

        public int TipoComunicacionId { get; set; }
        public string Prefijo { get; set; }
        public string Descripcion { get; set; }
        public int ConsecutivoActual { get; set; }

        public virtual ICollection<Comunicacion> Comunicacions { get; set; }
    }
}
