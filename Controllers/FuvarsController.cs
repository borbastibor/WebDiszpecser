using System;
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
    public class FuvarsController : Controller
    {
        private readonly FuvarozasDbContext _context;

        public FuvarsController(FuvarozasDbContext context)
        {
            _context = context;
        }

        // GET: Fuvars
        public IActionResult Index()
        {
            var fuvarozasDbContext = _context.Fuvarok.Include(f => f.Gepjarmu).Include(f => f.Sofor).OrderBy(f => f.IndulasIdeje);
            List<FuvarListViewModel> temp = new List<FuvarListViewModel>();
            foreach(var item in fuvarozasDbContext)
            {
                FuvarListViewModel fuvar = new FuvarListViewModel
                {
                    FuvarID = item.FuvarID,
                    Feladat = item.Feladat,
                    IndulasIdeje = item.IndulasIdeje.ToString("yyyy-MM-dd"),
                    BerakoCim = item.BerakoCim,
                    KirakoCim = item.KirakoCim,
                    GepjarmuTipus = item.Gepjarmu.Tipus,
                    SoforNev = item.Sofor.Csaladnev + " " + item.Sofor.Keresztnev
                };
                temp.Add(fuvar);
            }
            return View(temp);
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
            FuvarDetailsViewModel temp = new FuvarDetailsViewModel
            {
                FuvarID = fuvar.FuvarID,
                Feladat = fuvar.Feladat,
                IndulasIdeje = fuvar.IndulasIdeje.ToString("yyyy-MM-dd"),
                BerakoCim = fuvar.BerakoCim,
                KirakoCim = fuvar.KirakoCim,
                GjmuTipus = fuvar.Gepjarmu.Tipus + " (" + fuvar.Gepjarmu.Kategoria.ToString() + ")",
                GjmuRendszam = fuvar.Gepjarmu.Rendszam,
                GepjarmuID = fuvar.GepjarmuID,
                SoforNev = fuvar.Sofor.Csaladnev + " " + fuvar.Sofor.Keresztnev,
                JogositvanySzam = fuvar.Sofor.JogositvanySzam,
                JogsiErvenyesseg = fuvar.Sofor.Ervenyesseg.ToString("yyyy-MM-dd"),
                JogsiKategoria = fuvar.Sofor.Kategoria.ToString(),
                SoforID = fuvar.SoforID
            };

            return View(temp);
        }

        // GET: Fuvars/Create
        public IActionResult Create()
        {
            FuvarCreateViewModel temp = new FuvarCreateViewModel
            {
                GepjarmuList = GetGepjarmuvek(),
                SoforList = GetSoforok()
            };
            return View(temp);
        }

        // POST: Fuvars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuvarCreateViewModel ujfuvar)
        {
            Fuvar temp = new Fuvar
            {
                Feladat = ujfuvar.Feladat,
                BerakoCim = ujfuvar.BerakoCim,
                KirakoCim = ujfuvar.KirakoCim,
                IndulasIdeje = DateTime.Parse(ujfuvar.IndulasIdeje),
                GepjarmuID = int.Parse(ujfuvar.SelectedGepjarmu),
                Gepjarmu = _context.Gepjarmuvek.Find(int.Parse(ujfuvar.SelectedGepjarmu)),
                SoforID = int.Parse(ujfuvar.SelectedSofor),
                Sofor = _context.Soforok.Find(int.Parse(ujfuvar.SelectedSofor)),
            };
            _context.Fuvarok.Add(temp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Fuvars");
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
            FuvarCreateViewModel temp = new FuvarCreateViewModel
            {
                Feladat = fuvar.Feladat,
                BerakoCim = fuvar.BerakoCim,
                KirakoCim = fuvar.KirakoCim,
                IndulasIdeje = fuvar.IndulasIdeje.ToString("yyyy-MM-dd"),
                SelectedGepjarmu = fuvar.GepjarmuID.ToString(),
                GepjarmuList = GetGepjarmuvek(),
                SelectedSofor = fuvar.SoforID.ToString(),
                SoforList = GetSoforok()
            };
            return View(temp);
        }

        // POST: Fuvars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FuvarCreateViewModel fuvar)
        {
            Fuvar temp = new Fuvar
            {
                FuvarID = fuvar.FuvarID,
                Feladat = fuvar.Feladat,
                BerakoCim = fuvar.BerakoCim,
                KirakoCim = fuvar.KirakoCim,
                IndulasIdeje = DateTime.Parse(fuvar.IndulasIdeje),
                GepjarmuID = int.Parse(fuvar.SelectedGepjarmu),
                //Gepjarmu = _context.Gepjarmuvek.Find(int.Parse(fuvar.SelectedGepjarmu)),
                SoforID = int.Parse(fuvar.SelectedSofor),
                //Sofor = _context.Soforok.Find(int.Parse(fuvar.SelectedSofor))
            };
            try
            {
                _context.Fuvarok.Update(temp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuvarExists(temp.FuvarID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Fuvars");
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

        public IEnumerable<SelectListItem> GetGepjarmuvek()
        {
            List<SelectListItem> gepjarmuvek = _context.Gepjarmuvek.AsNoTracking()
                    .OrderBy(n => n.Tipus)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.GepjarmuID.ToString(),
                            Text = n.Tipus + " (" + n.Rendszam + ") - " + n.Kategoria.ToString()
                        }).ToList();
            var gepjarmuvektip = new SelectListItem()
            {
                Value = null,
                Text = "--- Válassz gépjárművet ---"
            };
            gepjarmuvek.Insert(0, gepjarmuvektip);
            return new SelectList(gepjarmuvek, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetSoforok()
        {
            List<SelectListItem> soforok = _context.Soforok.AsNoTracking()
                    .OrderBy(n => n.Csaladnev)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.SoforID.ToString(),
                            Text = n.Csaladnev + " " + n.Keresztnev + " (" + n.Kategoria.ToString() + ")"
                        }).ToList();
            var sofortip = new SelectListItem()
            {
                Value = null,
                Text = "--- Válassz sofőrt ---"
            };
            soforok.Insert(0, sofortip);
            return new SelectList(soforok, "Value", "Text").AsEnumerable();
        }
    }
}
