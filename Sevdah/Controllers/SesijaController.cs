using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;
using Sevdah.ViewModel;

namespace Sevdah.Controllers
{
    [Autorizacija(osoba:true)]
    public class SesijaController : Controller
    {
        private DBContext _db;

        public SesijaController(DBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
           
            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = _db.AutorizacijskiToken.Select(s => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = s.VrijemeEvidentiranja,
                token = s.Vrijednost,
                IpAdresa = s.IpAdresa
            }).ToList();
            model.TrenutniToken = HttpContext.GetTrenutniToken();
            return View(model);
        }

        public IActionResult Obrisi(string token)
        {
            AutorizacijskiToken obrisati =_db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                _db.AutorizacijskiToken.Remove(obrisati);
                _db.SaveChanges();
            }
            return RedirectToAction("Index","Authentication");
        }
    }
}