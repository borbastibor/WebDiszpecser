using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDiszpecser.Data;
using WebDiszpecser.Models;

namespace WebDiszpecser.Controllers
{
    public class FuvarsController : Controller
    {
        private readonly FuvarozasDbContext _context;

        public FuvarsController(FuvarozasDbContext context)
        {
            _context = context;
        }

        // GET: Fuvars
        public async Task<IActionResult> Index()
        {
            var fuvarozasDbContext = _context.Fuvarok.Include(f => f.Gepjarmu).Include(f => f.Sofor);
            return View(await fuvarozasDbContext.ToListAsync());
        }

        // GET: Fuvars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuvar = await _context.Fuvarok
                .Include(f => f.Gepjarmu)
                .Include(f => f.Sofor)
                .FirstOrDefaultAsync(m => m.FuvarID == id);
            if (fuvar == null)
            {
                return NotFound();
            }

            return View(fuvar);
        }

        // GET: Fuvars/Create
        public IActionResult Create()
        {
            ViewData["GepjarmuID"] = new SelectList(_context.Gepjarmuvek, "GepjarmuID", "Rendszam");
            ViewData["SoforID"] = new SelectList(_context.Soforok, "SoforID", "Csaladnev");
            return View();
        }

        // POST: Fuvars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuvarID,Feladat,IndulasIdeje,BerakoCim,KirakoCim,GepjarmuID,SoforID")] Fuvar fuvar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuvar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GepjarmuID"] = new SelectList(_context.Gepjarmuvek, "GepjarmuID", "Rendszam", fuvar.GepjarmuID);
            ViewData["SoforID"] = new SelectList(_context.Soforok, "SoforID", "Csaladnev", fuvar.SoforID);
            return View(fuvar);
        }

        // GET: Fuvars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuvar = await _context.Fuvarok.FindAsync(id);
            if (fuvar == null)
            {
                return NotFound();
            }
            ViewData["GepjarmuID"] = new SelectList(_context.Gepjarmuvek, "GepjarmuID", "Rendszam", fuvar.GepjarmuID);
            ViewData["SoforID"] = new SelectList(_context.Soforok, "SoforID", "Csaladnev", fuvar.SoforID);
            return View(fuvar);
        }

        // POST: Fuvars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuvarID,Feladat,IndulasIdeje,BerakoCim,KirakoCim,GepjarmuID,SoforID")] Fuvar fuvar)
        {
            if (id != fuvar.FuvarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuvar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuvarExists(fuvar.FuvarID))
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
            ViewData["GepjarmuID"] = new SelectList(_context.Gepjarmuvek, "GepjarmuID", "Rendszam", fuvar.GepjarmuID);
            ViewData["SoforID"] = new SelectList(_context.Soforok, "SoforID", "Csaladnev", fuvar.SoforID);
            return View(fuvar);
        }

        // GET: Fuvars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuvar = await _context.Fuvarok
                .Include(f => f.Gepjarmu)
                .Include(f => f.Sofor)
                .FirstOrDefaultAsync(m => m.FuvarID == id);
            if (fuvar == null)
            {
                return NotFound();
            }

            return View(fuvar);
        }

        // POST: Fuvars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuvar = await _context.Fuvarok.FindAsync(id);
            _context.Fuvarok.Remove(fuvar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuvarExists(int id)
        {
            return _context.Fuvarok.Any(e => e.FuvarID == id);
        }
    }
}
