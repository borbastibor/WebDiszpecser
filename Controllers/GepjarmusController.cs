using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDiszpecser.Data;
using WebDiszpecser.Models;

namespace WebDiszpecser.Controllers
{
    public class GepjarmusController : Controller
    {
        private readonly FuvarozasDbContext _context;

        public GepjarmusController(FuvarozasDbContext context)
        {
            _context = context;
        }

        // GET: Gepjarmus
        public IActionResult Index()
        {
            var gepjarmuDbContext = _context.Gepjarmuvek.Include(g => g.Telephely);
            List<GepjarmuListViewModel> temp = new List<GepjarmuListViewModel>();
            foreach(var item in gepjarmuDbContext)
            {
                GepjarmuListViewModel gjmu = new GepjarmuListViewModel
                {
                    GepjarmuID = item.GepjarmuID,
                    Rendszam = item.Rendszam,
                    FutottKm = item.FutottKm,
                    Tipus = item.Tipus,
                    Kategoria = item.Kategoria,
                    TelephelyCim = item.Telephely.TelephelyCim
                };
                temp.Add(gjmu);
            }
            return View(temp);
        }

        // GET: Gepjarmus/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gepjarmu = _context.Gepjarmuvek
                .Include(g => g.Telephely)
                .FirstOrDefault(m => m.GepjarmuID == id);
            if (gepjarmu == null)
            {
                return NotFound();
            }
            GepjarmuDetailsViewModel temp = new GepjarmuDetailsViewModel
            {
                GepjarmuID = gepjarmu.GepjarmuID,
                Rendszam = gepjarmu.Rendszam,
                FutottKm = gepjarmu.FutottKm,
                Tipus = gepjarmu.Tipus,
                Kategoria = gepjarmu.Kategoria,
                SzervizCiklus = gepjarmu.SzervizCiklus,
                UtolsoSzerviz = gepjarmu.UtolsoSzerviz.ToString("yyyy-MM-dd"),
                TelephelyCim = gepjarmu.Telephely.TelephelyCim
            };
            return View(temp);
        }

        // GET: Gepjarmus/Create
        public IActionResult Create()
        {
            ViewData["TelephelyID"] = new SelectList(_context.Telephelyek, "TelephelyID", "TelephelyCim");
            return View();
        }

        // POST: Gepjarmus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GepjarmuID,Tipus,Rendszam,FutottKm,SzervizCiklus,UtolsoSzerviz,Kategoria,TelephelyID")] Gepjarmu gepjarmu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gepjarmu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TelephelyID"] = new SelectList(_context.Telephelyek, "TelephelyID", "TelephelyCim", gepjarmu.TelephelyID);
            return View(gepjarmu);
        }

        // GET: Gepjarmus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gepjarmu = await _context.Gepjarmuvek.FindAsync(id);
            if (gepjarmu == null)
            {
                return NotFound();
            }
            ViewData["TelephelyID"] = new SelectList(_context.Telephelyek, "TelephelyID", "TelephelyCim", gepjarmu.TelephelyID);
            return View(gepjarmu);
        }

        // POST: Gepjarmus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GepjarmuID,Tipus,Rendszam,FutottKm,SzervizCiklus,UtolsoSzerviz,Kategoria,TelephelyID")] Gepjarmu gepjarmu)
        {
            if (id != gepjarmu.GepjarmuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gepjarmu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GepjarmuExists(gepjarmu.GepjarmuID))
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
            ViewData["TelephelyID"] = new SelectList(_context.Telephelyek, "TelephelyID", "TelephelyCim", gepjarmu.TelephelyID);
            return View(gepjarmu);
        }

        // GET: Gepjarmus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gepjarmu = await _context.Gepjarmuvek
                .Include(g => g.Telephely)
                .FirstOrDefaultAsync(m => m.GepjarmuID == id);
            if (gepjarmu == null)
            {
                return NotFound();
            }

            return View(gepjarmu);
        }

        // POST: Gepjarmus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gepjarmu = await _context.Gepjarmuvek.FindAsync(id);
            _context.Gepjarmuvek.Remove(gepjarmu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GepjarmuExists(int id)
        {
            return _context.Gepjarmuvek.Any(e => e.GepjarmuID == id);
        }
    }
}
