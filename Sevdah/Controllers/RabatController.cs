using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sevdah.ViewModel;
using Sevdah.Data;
using Microsoft.EntityFrameworkCore;
using Sevdah.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Helpers;

namespace Sevdah.Controllers
{

    [Autorizacija(osoba: true)]
    public class RabatController : Controller
    {
        DBContext db;

        public RabatController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int KupacID)
        {
            List<Kupac> model = db.Kupci.ToList();


            return View(model);
        }


        public IActionResult IndexKupac(int KupacID)
        {
            RabatIndexVM model = new RabatIndexVM();

            model.rabati = db.OdobreniRabat.Include(x=>x.Proizvod).Where(p=>p.KupacID==KupacID).ToList();

            model.Kupac = db.Kupci.Where(x => x.KupacID == KupacID).FirstOrDefault();

            return View(model);
        }


        public IActionResult Uredi(int rabatID)
        {
            OdobreniRabat model = db.OdobreniRabat.Include(y=>y.Proizvod).Include(p=>p.Kupac).Where(x => x.OdobreniRabatID == rabatID).FirstOrDefault();

            return View(model);
        }

        public IActionResult Snimi(OdobreniRabat model)
        {
            OdobreniRabat edit = db.OdobreniRabat.Where(x => x.OdobreniRabatID == model.OdobreniRabatID).FirstOrDefault();
            edit.IznosPostotci = model.IznosPostotci;

            db.OdobreniRabat.Update(edit);

            db.SaveChanges();

            return RedirectToAction(nameof(IndexKupac), new { KupacID = model.KupacID });
        }
    }
}