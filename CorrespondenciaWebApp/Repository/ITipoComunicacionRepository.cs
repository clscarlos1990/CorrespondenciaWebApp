using CorrespondenciaWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorrespondenciaWebApp.Repository
{
    public interface ITipoComunicacionRepository
    {
        Task<TipoComunicacion> Create(TipoComunicacion tipoComunicacion);

        Task<IEnumerable<TipoComunicacion>> FindAll();

        Task<TipoComunicacion> FindById(int? tipoComunicacionId);

        Task<TipoComunicacion> Update(TipoComunicacion tipoComunicacion);
    }
}
