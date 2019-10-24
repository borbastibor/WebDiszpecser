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
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuvar = _context.Fuvarok
                .Include(f => f.Gepjarmu)
                .Include(f => f.Sofor)
                .FirstOrDefault(m => m.FuvarID == id);
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
        public IActionResult Create(FuvarCreateViewModel ujfuvar)
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
            _context.SaveChanges();
            return RedirectToAction("Index", "Fuvars");
        }

        // GET: Fuvars/Edit/5
        public IActionResult Edit(int id)
        {
            var fuvar = _context.Fuvarok.Find(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FuvarID,Feladat,IndulasIdeje,BerakoCim,KirakoCim,SelectedGepjarmu,SelectedSofor")]FuvarCreateViewModel fuvar)
        {
            var actualfuvar = _context.Fuvarok.Find(id);
            if (actualfuvar == null)
            {
                return NotFound();
            }
            actualfuvar.Feladat = fuvar.Feladat;
            actualfuvar.BerakoCim = fuvar.BerakoCim;
            actualfuvar.KirakoCim = fuvar.KirakoCim;
            actualfuvar.IndulasIdeje = DateTime.Parse(fuvar.IndulasIdeje);
            actualfuvar.GepjarmuID = int.Parse(fuvar.SelectedGepjarmu);
            actualfuvar.Gepjarmu = _context.Gepjarmuvek.Find(int.Parse(fuvar.SelectedGepjarmu));
            actualfuvar.SoforID = int.Parse(fuvar.SelectedSofor);
            actualfuvar.Sofor = _context.Soforok.Find(int.Parse(fuvar.SelectedSofor));

            try
            {
                _context.Update(actualfuvar);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuvarExists(actualfuvar.FuvarID))
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuvar = _context.Fuvarok
                .Include(f => f.Gepjarmu)
                .Include(f => f.Sofor)
                .FirstOrDefault(m => m.FuvarID == id);
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

        // POST: Fuvars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var fuvar = _context.Fuvarok.Find(id);
            _context.Fuvarok.Remove(fuvar);
            _context.SaveChanges();
            return RedirectToAction("Index", "Fuvars");
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
