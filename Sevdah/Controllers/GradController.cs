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
    public class GradController : Controller
    {
        DBContext db;

        public GradController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Dodaj()
        {
            Grad model = new Grad();
            return View(model);
        }

        public IActionResult Spasi(Grad Model)
        {

            db.Gradovi.Add(Model);
            db.SaveChanges();

            return RedirectToAction("Index", "Kupac");
        }

    }
}