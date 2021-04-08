using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
            Personas = new HashSet<Persona>();
        }

        public int TipoIdenticacionId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
