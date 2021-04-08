using System;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class Comunicacion
    {
        public int ComunicacionId { get; set; }
        public string Consecutivo { get; set; }
        public int TipoComunicacionId { get; set; }
        public int PersonaIdRemite { get; set; }
        public int PersonaIdDestino { get; set; }
        public int UsuarioIdRegistra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreArchivo { get; set; }
        public byte[] Archivo { get; set; }

        public virtual Persona PersonaIdDestinoNavigation { get; set; }
        public virtual Persona PersonaIdRemiteNavigation { get; set; }
        public virtual TipoComunicacion TipoComunicacion { get; set; }
        public virtual Usuario UsuarioIdRegistraNavigation { get; set; }
    }
}
