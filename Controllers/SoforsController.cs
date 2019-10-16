using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDiszpecser.Data;
using WebDiszpecser.Models;

namespace WebDiszpecser.Controllers
{
    public class SoforsController : Controller
    {
        private readonly FuvarozasDbContext _context;

        public SoforsController(FuvarozasDbContext context)
        {
            _context = context;
        }

        // GET: Sofors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Soforok.ToListAsync());
        }

        // GET: Sofors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Soforok
                .FirstOrDefaultAsync(m => m.SoforID == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // GET: Sofors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sofors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoforID,Csaladnev,Keresztnev,SzulIdo,JogositvanySzam,Ervenyesseg,Kategoria")] Sofor sofor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sofor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sofor);
        }

        // GET: Sofors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Soforok.FindAsync(id);
            if (sofor == null)
            {
                return NotFound();
            }
            return View(sofor);
        }

        // POST: Sofors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoforID,Csaladnev,Keresztnev,SzulIdo,JogositvanySzam,Ervenyesseg,Kategoria")] Sofor sofor)
        {
            if (id != sofor.SoforID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sofor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoforExists(sofor.SoforID))
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
            return View(sofor);
        }

        // GET: Sofors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Soforok
                .FirstOrDefaultAsync(m => m.SoforID == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // POST: Sofors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sofor = await _context.Soforok.FindAsync(id);
            _context.Soforok.Remove(sofor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoforExists(int id)
        {
            return _context.Soforok.Any(e => e.SoforID == id);
        }
    }
}
