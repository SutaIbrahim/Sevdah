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
            return View(new Grad());
        }

        public IActionResult Spasi(Grad Model)
        {
            db.Gradovi.Add(Model);
            db.SaveChanges();

            return RedirectToAction("Index", "Kupac");
        }
    }
}