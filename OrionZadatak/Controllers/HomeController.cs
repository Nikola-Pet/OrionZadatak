using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrionZadatak.Entities;
using OrionZadatak.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrionZadatakContext _context;


        public HomeController(ILogger<HomeController> logger, OrionZadatakContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new UgovorView();
            model.KolekcijaUgovora5 = _context.Ugovori.OrderByDescending(x => x.DatumKreiranja).Take(5).ToList();

            model.KolekcijaAktivnihUgovora = _context.Ugovori.Where(x => x.Status == true).ToList();

            

            return View(model);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
