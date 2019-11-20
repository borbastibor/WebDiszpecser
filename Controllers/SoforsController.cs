using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            var soforDbContext = _context.Soforok.OrderBy(f => f.Csaladnev);
            List<SoforListViewModel> temp = new List<SoforListViewModel>();
            foreach (var item in soforDbContext)
            {
                SoforListViewModel sofor = new SoforListViewModel
                {
                    SoforID = item.SoforID,
                    Csaladnev = item.Csaladnev,
                    Keresztnev = item.Keresztnev,
                    SzulIdo = item.SzulIdo.ToString("yyyy-MM-dd"),
                    JogositvanySzam = item.JogositvanySzam,
                    Ervenyesseg = item.Ervenyesseg.ToString("yyyy-MM-dd"),
                    Kategoria = item.Kategoria
                };
                temp.Add(sofor);
            }
            return View(temp);
        }

        // GET: Sofors/Create
        public IActionResult Create()
        {
            SoforCreateViewModel temp = new SoforCreateViewModel();
            return View(temp);
        }

        // POST: Sofors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SoforCreateViewModel sofor)
        {
            if (ModelState.IsValid)
            {
                Sofor soformodel = new Sofor
                {
                    Csaladnev = sofor.Csaladnev,
                    Keresztnev = sofor.Keresztnev,
                    SzulIdo = DateTime.Parse(sofor.SzulIdo),
                    JogositvanySzam = sofor.JogositvanySzam,
                    Ervenyesseg = DateTime.Parse(sofor.Ervenyesseg),
                    Kategoria = sofor.Kategoria
                };
                _context.Add(soformodel);
                _context.SaveChanges();
                return RedirectToAction("Index", "Sofors");
            }
            return View(sofor);
        }

        // GET: Sofors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = _context.Soforok.Find(id);
            if (sofor == null)
            {
                return NotFound();
            }
            SoforCreateViewModel temp = new SoforCreateViewModel
            {
                SoforID = sofor.SoforID,
                Csaladnev = sofor.Csaladnev,
                Keresztnev = sofor.Keresztnev,
                SzulIdo = sofor.SzulIdo.ToString("yyyy-MM-dd"),
                JogositvanySzam = sofor.JogositvanySzam,
                Ervenyesseg = sofor.Ervenyesseg.ToString("yyyy-MM-dd"),
                Kategoria = sofor.Kategoria
            };
            return View(temp);
        }

        // POST: Sofors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SoforCreateViewModel sofor)
        {
            if (id != sofor.SoforID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Sofor soformodel = new Sofor
                {
                    Csaladnev = sofor.Csaladnev,
                    Keresztnev = sofor.Keresztnev,
                    SzulIdo = DateTime.Parse(sofor.SzulIdo),
                    JogositvanySzam = sofor.JogositvanySzam,
                    Ervenyesseg = DateTime.Parse(sofor.Ervenyesseg),
                    Kategoria = sofor.Kategoria
                };
                try
                {
                    _context.Update(soformodel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoforExists(soformodel.SoforID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Sofors");
            }
            return View(sofor);
        }

        // GET: Sofors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = _context.Soforok
                .FirstOrDefault(m => m.SoforID == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // POST: Sofors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sofor = _context.Soforok.Find(id);
            _context.Soforok.Remove(sofor);
            _context.SaveChanges();
            return RedirectToAction("Index", "Sofors");
        }

        private bool SoforExists(int id)
        {
            return _context.Soforok.Any(e => e.SoforID == id);
        }
    }
}
