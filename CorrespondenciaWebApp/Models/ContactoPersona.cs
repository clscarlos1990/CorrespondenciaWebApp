#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class ContactoPersona
    {
        public int ContactoId { get; set; }
        public int TipoContactoId { get; set; }
        public int PersonaId { get; set; }
        public string Contacto { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual TipoContacto TipoContacto { get; set; }
    }
}
