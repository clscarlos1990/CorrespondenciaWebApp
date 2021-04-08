using CorrespondenciaWebApp.Models;
using CorrespondenciaWebApp.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using CorrespondenciaWebApp.Repository;

namespace CorrespondenciaWebApp.Controllers
{
    public class ComunicacionController : Controller
    {
        private readonly DB_CorrespondenciaContext _context;
        private ILogger<ComunicacionController> _logger;
        private readonly ITipoComunicacionRepository _TipoComunicacionRepository;
        public ComunicacionController(DB_CorrespondenciaContext context,
                ILogger<ComunicacionController> logger, ITipoComunicacionRepository tipoComunicacionRepository)
        {
            _context = context;
            _logger = logger;
            _TipoComunicacionRepository = tipoComunicacionRepository;
        }

        // GET: Comunicacion
        public async Task<IActionResult> Index()
        {
            var dB_CorrespondenciaContext = _context.Comunicacions.Include(c => c.PersonaIdDestinoNavigation).Include(c => c.PersonaIdRemiteNavigation).Include(c => c.TipoComunicacion).Include(c => c.UsuarioIdRegistraNavigation);
            return View(await dB_CorrespondenciaContext.ToListAsync());
        }

        // GET: Comunicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comunicacion = await _context.Comunicacions
                .Include(c => c.PersonaIdDestinoNavigation)
                .Include(c => c.PersonaIdRemiteNavigation)
                .Include(c => c.TipoComunicacion)
                .Include(c => c.UsuarioIdRegistraNavigation)
                .FirstOrDefaultAsync(m => m.ComunicacionId == id);
            if (comunicacion == null)
            {
                _logger.LogInformation("No existen registros en Base de Datos");
                return NotFound();
            }
            _logger.LogInformation("Obteniendo listado de Comunicaciones");
            return View(comunicacion);
        }

        // GET: Comunicacion/Create
        public IActionResult Create()
        {
            ViewData["PersonaIdDestino"] = new SelectList(_context.Personas, "PersonaId", "Apellidos");
            ViewData["PersonaIdRemite"] = new SelectList(_context.Personas, "PersonaId", "Apellidos");
            ViewData["TipoComunicacionId"] = new SelectList(_context.TipoComunicacions, "TipoComunicacionId", "Descripcion");
            ViewData["UsuarioIdRegistra"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasena");
            return View();
        }

        // POST: Comunicacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComunicacionId,Consecutivo,TipoComunicacionId,PersonaIdRemite,PersonaIdDestino,UsuarioIdRegistra,FechaRegistro,NombreArchivo,Archivo")] Comunicacion comunicacion)
        {
            if (ModelState.IsValid)
            {
                TipoComunicacion tipoComunicacion = await _TipoComunicacionRepository.FindById(comunicacion.TipoComunicacionId);
                tipoComunicacion.ConsecutivoActual += 1;
                string consecutivo = tipoComunicacion.Prefijo + (tipoComunicacion.ConsecutivoActual).ToString("00000000");
                tipoComunicacion = await _TipoComunicacionRepository.Update(tipoComunicacion);
                comunicacion.Consecutivo = consecutivo;
                _context.Add(comunicacion);
                await _context.SaveChangesAsync();

                _logger.LogError("El comunicado fue almacenado con exito");

                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaIdDestino"] = new SelectList(_context.Personas, "PersonaId", "Apellidos", comunicacion.PersonaIdDestino);
            ViewData["PersonaIdRemite"] = new SelectList(_context.Personas, "PersonaId", "Apellidos", comunicacion.PersonaIdRemite);
            ViewData["TipoComunicacionId"] = new SelectList(_context.TipoComunicacions, "TipoComunicacionId", "Descripcion", comunicacion.TipoComunicacionId);
            ViewData["UsuarioIdRegistra"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasena", comunicacion.UsuarioIdRegistra);
            _logger.LogInformation("El registro se crea correctamente");
            return View(comunicacion);
        }

        // GET: Comunicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comunicacion = await _context.Comunicacions.FindAsync(id);
            if (comunicacion == null)
            {
                return NotFound();
            }
            ViewData["PersonaIdDestino"] = new SelectList(_context.Personas, "PersonaId", "Apellidos", comunicacion.PersonaIdDestino);
            ViewData["PersonaIdRemite"] = new SelectList(_context.Personas, "PersonaId", "Apellidos", comunicacion.PersonaIdRemite);
            ViewData["TipoComunicacionId"] = new SelectList(_context.TipoComunicacions, "TipoComunicacionId", "Descripcion", comunicacion.TipoComunicacionId);
            ViewData["UsuarioIdRegistra"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasena", comunicacion.UsuarioIdRegistra);
            return View(comunicacion);
        }

        // POST: Comunicacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComunicacionId,Consecutivo,TipoComunicacionId,PersonaIdRemite,PersonaIdDestino,UsuarioIdRegistra,FechaRegistro,NombreArchivo,Archivo")] Comunicacion comunicacion)
        {
            if (id != comunicacion.ComunicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunicacionExists(comunicacion.ComunicacionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaIdDestino"] = new SelectList(_context.Personas, "PersonaId", "Apellidos", comunicacion.PersonaIdDestino);
            ViewData["PersonaIdRemite"] = new SelectList(_context.Personas, "PersonaId", "Apellidos", comunicacion.PersonaIdRemite);
            ViewData["TipoComunicacionId"] = new SelectList(_context.TipoComunicacions, "TipoComunicacionId", "Descripcion", comunicacion.TipoComunicacionId);
            ViewData["UsuarioIdRegistra"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasena", comunicacion.UsuarioIdRegistra);
            return View(comunicacion);
        }

        // GET: Comunicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comunicacion = await _context.Comunicacions
                .Include(c => c.PersonaIdDestinoNavigation)
                .Include(c => c.PersonaIdRemiteNavigation)
                .Include(c => c.TipoComunicacion)
                .Include(c => c.UsuarioIdRegistraNavigation)
                .FirstOrDefaultAsync(m => m.ComunicacionId == id);
            if (comunicacion == null)
            {
                return NotFound();
            }

            return View(comunicacion);
        }

        // POST: Comunicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comunicacion = await _context.Comunicacions.FindAsync(id);
            _context.Comunicacions.Remove(comunicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunicacionExists(int id)
        {
            return _context.Comunicacions.Any(e => e.ComunicacionId == id);
        }
    }
}
