using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;
using Sevdah.ViewModel;

namespace Sevdah.Controllers
{
    [Autorizacija(osoba: true)]

    public class SkladisteController : Controller
    {
        DBContext db;

        public SkladisteController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {

            List<Skladiste> model = db.Skladiste.ToList();


            return View(model);
        }

        public IActionResult Uredi(int skladisteID)
        {
            SkladisteUrediVM model = new SkladisteUrediVM();

            model.Skladiste = db.Skladiste.Where(x => x.SkladisteID == skladisteID).FirstOrDefault();
            model.Nova = 0;

            return View(model);
        }

        public IActionResult Snimi(SkladisteUrediVM model)
        {
            Skladiste skladiste = db.Skladiste.Where(x => x.SkladisteID == model.Skladiste.SkladisteID).FirstOrDefault();

            float nova = model.Nova;
            skladiste.KolicinaUKg += nova;

            db.Skladiste.Update(skladiste);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult PrikaziPdf()
        {
            SkladistePrikaziPdfVM Model = new SkladistePrikaziPdfVM();
            Model._listaProizvoda = new List<Skladiste>(); ;
            Model._listaProizvoda = db.Skladiste.ToList();
            SkladisteReport noviReport = new SkladisteReport();
            byte[] docArray = noviReport.PrepareReport(Model);
            return File(docArray, "application/pdf");
        }

    }
}