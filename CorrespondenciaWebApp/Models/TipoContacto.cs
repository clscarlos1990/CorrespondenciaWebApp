using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class TipoContacto
    {
        public TipoContacto()
        {
            ContactoPersonas = new HashSet<ContactoPersona>();
        }

        public int TipoContactoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; }
    }
}
