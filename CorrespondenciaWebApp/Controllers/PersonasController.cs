using CorrespondenciaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CorrespondenciaWebApp.Controllers
{
    public class PersonasController : Controller
    {
        private readonly DB_CorrespondenciaContext _context;

        public PersonasController(DB_CorrespondenciaContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var dB_CorrespondenciaContext = _context.Personas.Include(p => p.TipoIdenticacion);
            return View(await dB_CorrespondenciaContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.TipoIdenticacion)
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["TipoIdenticacionId"] = new SelectList(_context.TipoIdentificacions, "TipoIdenticacionId", "Codigo");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaId,Identificacion,TipoIdenticacionId,Nombres,Apellidos")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdenticacionId"] = new SelectList(_context.TipoIdentificacions, "TipoIdenticacionId", "Codigo", persona.TipoIdenticacionId);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["TipoIdenticacionId"] = new SelectList(_context.TipoIdentificacions, "TipoIdenticacionId", "Codigo", persona.TipoIdenticacionId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaId,Identificacion,TipoIdenticacionId,Nombres,Apellidos")] Persona persona)
        {
            if (id != persona.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.PersonaId))
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
            ViewData["TipoIdenticacionId"] = new SelectList(_context.TipoIdentificacions, "TipoIdenticacionId", "Codigo", persona.TipoIdenticacionId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.TipoIdenticacion)
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.PersonaId == id);
        }
    }
}
