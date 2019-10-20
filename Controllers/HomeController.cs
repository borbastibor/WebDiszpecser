using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebDiszpecser.Data;
using WebDiszpecser.Models;

namespace WebDiszpecser.Controllers
{
    public class HomeController : Controller
    {
        private readonly FuvarozasDbContext _context;

        public HomeController(FuvarozasDbContext context)

        {

            _context = context;

        }
        public IActionResult Index()
        {
            IndexViewModel temp = new IndexViewModel
            {
                BefejezettFuvarok = _context.Fuvarok.Where(f => f.IndulasIdeje < DateTime.Now).Count(),
                OsszesFuvar = _context.Fuvarok.Count(),
                SoforLetszam = _context.Soforok.Count(),
                GepjarmuDarab = _context.Gepjarmuvek.Count()
            };
            return View(temp);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}