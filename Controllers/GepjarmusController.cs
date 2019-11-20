using System;
using System.Collections.Generic;
using System.Linq;
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
            GepjarmuCreateViewModel temp = new GepjarmuCreateViewModel
            {
                Telephelyek = GetTelephelyek()
            };
            return View(temp);
        }

        // POST: Gepjarmus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GepjarmuCreateViewModel gepjarmu)
        {
            if (ModelState.IsValid)
            {
                Gepjarmu temp = new Gepjarmu
                {
                    Tipus = gepjarmu.Tipus,
                    Rendszam = gepjarmu.Rendszam,
                    FutottKm = gepjarmu.FutottKm,
                    Kategoria = gepjarmu.Kategoria,
                    SzervizCiklus = gepjarmu.SzervizCiklus,
                    UtolsoSzerviz = DateTime.Parse(gepjarmu.UtolsoSzerviz),
                    TelephelyID = int.Parse(gepjarmu.SelectedTelephelyCim),
                    Telephely = _context.Telephelyek.Find(int.Parse(gepjarmu.SelectedTelephelyCim))
                };
                _context.Gepjarmuvek.Add(temp);
                _context.SaveChanges();
                return RedirectToAction("Index", "Gepjarmus");
            }
            gepjarmu.Telephelyek = GetTelephelyek();
            return View(gepjarmu);
        }

        // GET: Gepjarmus/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gepjarmu = _context.Gepjarmuvek.Include(t => t.Telephely)
                .FirstOrDefault(g => g.GepjarmuID == id);
            if (gepjarmu == null)
            {
                return NotFound();
            }

            GepjarmuCreateViewModel temp = new GepjarmuCreateViewModel
            {
                GepjarmuID = gepjarmu.GepjarmuID,
                Tipus = gepjarmu.Tipus,
                Rendszam = gepjarmu.Rendszam,
                FutottKm = gepjarmu.FutottKm,
                Kategoria = gepjarmu.Kategoria,
                SzervizCiklus = gepjarmu.SzervizCiklus,
                UtolsoSzerviz = gepjarmu.UtolsoSzerviz.ToString("yyyy-MM-dd"),
                SelectedTelephelyCim = gepjarmu.Telephely.TelephelyID.ToString(),
                Telephelyek = GetTelephelyek()
            };
            return View(temp);
        }

        // POST: Gepjarmus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GepjarmuID,Tipus,Rendszam,FutottKm,SzervizCiklus,UtolsoSzerviz,Kategoria,SelectedTelephelyCim")] GepjarmuCreateViewModel gepjarmu)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Gepjarmuvek.Find(id);
                if (temp == null)
                {
                    return NotFound();
                }
                temp.Tipus = gepjarmu.Tipus;
                temp.Rendszam = gepjarmu.Rendszam;
                temp.Kategoria = gepjarmu.Kategoria;
                temp.FutottKm = gepjarmu.FutottKm;
                temp.UtolsoSzerviz = DateTime.Parse(gepjarmu.UtolsoSzerviz);
                temp.SzervizCiklus = gepjarmu.SzervizCiklus;
                temp.TelephelyID = int.Parse(gepjarmu.SelectedTelephelyCim);
                temp.Telephely = _context.Telephelyek.Find(int.Parse(gepjarmu.SelectedTelephelyCim));
                try
                {
                    _context.Update(temp);
                    _context.SaveChanges();
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
                return RedirectToAction("Index", "Gepjarmus");
            }
            gepjarmu.Telephelyek = GetTelephelyek();
            return View(gepjarmu);
        }

        // GET: Gepjarmus/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gepjarmu = _context.Gepjarmuvek
                .Include(f => f.Telephely)
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

        // POST: Gepjarmus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var gepjarmu = _context.Gepjarmuvek.Find(id);
            _context.Gepjarmuvek.Remove(gepjarmu);
            _context.SaveChanges();
            return RedirectToAction("Index", "Gepjarmus");
        }

        private bool GepjarmuExists(int id)
        {
            return _context.Gepjarmuvek.Any(e => e.GepjarmuID == id);
        }

        private IEnumerable<SelectListItem> GetTelephelyek()
        {
            List<SelectListItem> telephelyek = _context.Telephelyek.AsNoTracking()
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.TelephelyID.ToString(),
                            Text = n.TelephelyCim
                        }).ToList();
            return new SelectList(telephelyek, "Value", "Text");
        }
    }
}
