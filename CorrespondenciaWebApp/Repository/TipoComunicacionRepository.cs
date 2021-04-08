using CorrespondenciaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrespondenciaWebApp.Repository
{
    public class TipoComunicacionRepository : ITipoComunicacionRepository
    {
        private readonly DB_CorrespondenciaContext _context;

        public TipoComunicacionRepository(DB_CorrespondenciaContext context)
        {
            _context = context;
        }
        public Task<TipoComunicacion> Create(TipoComunicacion tipoComunicacion)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.TipoComunicacions.Add(tipoComunicacion);
                    _context.SaveChanges();
                    return tipoComunicacion;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error:" + e);
                }
                return null;
            });
        }

        public Task<IEnumerable<TipoComunicacion>> FindAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _context.TipoComunicacions.OrderBy(v => v.TipoComunicacionId).AsEnumerable();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error:" + e);
                }
                return null;
            });
        }

        public Task<TipoComunicacion> FindById(int? tipoComunicacionId)
        {
            return Task.Run(() =>
            {
                if (tipoComunicacionId != null)
                {
                    try
                    {
                        var tipoComunicacion = _context.TipoComunicacions.Where(v => v.TipoComunicacionId == tipoComunicacionId).First();
                        if (tipoComunicacion != null)
                        {
                            return tipoComunicacion;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error:" + e);
                    }
                }

                return null;
            });
        }

        public Task<TipoComunicacion> Update(TipoComunicacion tipoComunicacion)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.TipoComunicacions.Update(tipoComunicacion);
                    _context.SaveChanges();
                    return tipoComunicacion;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error:" + e);
                }
                return null;
            });
        }
    }
}
