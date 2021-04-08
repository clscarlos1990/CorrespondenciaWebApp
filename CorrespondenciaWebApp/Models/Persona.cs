using System.Collections.Generic;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Persona
    {
        public Persona()
        {
            ComunicacionPersonaIdDestinoNavigations = new HashSet<Comunicacion>();
            ComunicacionPersonaIdRemiteNavigations = new HashSet<Comunicacion>();
            ContactoPersonas = new HashSet<ContactoPersona>();
        }

        public int PersonaId { get; set; }
        public string Identificacion { get; set; }
        public int TipoIdenticacionId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public virtual TipoIdentificacion TipoIdenticacion { get; set; }
        public virtual ICollection<Comunicacion> ComunicacionPersonaIdDestinoNavigations { get; set; }
        public virtual ICollection<Comunicacion> ComunicacionPersonaIdRemiteNavigations { get; set; }
        public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; }
    }
}
