using CorrespondenciaWebApp.Models;
using CorrespondenciaWebApp.Repository;
using System;
using System.Threading.Tasks;

namespace CorrespondenciaWebApp.Tools
{
    public class Herramientas
    {
        private readonly TipoComunicacionRepository _repository;

        public Herramientas(TipoComunicacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> CrearConsecutivo(int tipoComunicacionId)
        {
            TipoComunicacion tipoComunicacion = await _repository.FindById(tipoComunicacionId);
            String consecutivo = tipoComunicacion.Prefijo + (tipoComunicacion.ConsecutivoActual + 1).ToString("00000000");
            return consecutivo;
        }
    }
}
