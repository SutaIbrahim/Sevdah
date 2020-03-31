using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;

namespace Sevdah.Controllers
{
    [Autorizacija(osoba: true)]

    public class VrsteProizvodaController : Controller
    {


        DBContext db;
        public VrsteProizvodaController(DBContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            List<VrstaProizvoda> model = db.VrsteProizvoda.ToList();


            return View(model);
        }

        public IActionResult Dodaj()
        {
            VrstaProizvoda model = new VrstaProizvoda();

            return View(model);
        }
        public IActionResult Spasi(VrstaProizvoda Model)
        {

            db.VrsteProizvoda.Add(Model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int VrstaID)
        {
            VrstaProizvoda del = db.VrsteProizvoda.Where(x => x.VrstaProizvodaID == VrstaID).FirstOrDefault();

            db.VrsteProizvoda.Remove(del);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}