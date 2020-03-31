using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.ViewModel;
using Sevdah.Models;
using Sevdah.Helpers;

namespace Sevdah.Controllers
{

    [Autorizacija(osoba: true)]
    public class ProizvodiController : Controller
    {
        private DBContext _db;
        public ProizvodiController(DBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ProizvodiIndexVM Model = new ProizvodiIndexVM();
            Model.listaProizvoda = new List<ProizvodiIndexVM.Row>();
            Model.listaProizvoda = _db.Proizvodi.Select(x => new ProizvodiIndexVM.Row
            {
                ProizvodId = x.ProizvodID,
                Naziv = x.Naziv,
                CijenaBezPDV = x.CijenaBezPDV,
                CijenaSaPDV = x.CijenaSaPDV,
                MasaUKg = x.Masa,
                BarKod = x.BarKod
            }).ToList();
            return View(Model);
        }
        public IActionResult Dodaj()
        {
            ProizvodiDodajVM Model = new ProizvodiDodajVM();
            Model.proizvod = new Models.Proizvod();
            Model.listaSkladista = new List<SelectListItem>();
            Model.listaSkladista = _db.Skladiste.Select(x => new SelectListItem
            {
                Value = x.SkladisteID.ToString(),
                Text = x.VrstaKafe
            }).ToList();
            return View(Model);
        }
        public IActionResult Snimi(ProizvodiDodajVM model)
        {
            Proizvod novi;
            if (model.proizvod.ProizvodID != 0)
            {
                novi = _db.Proizvodi.Where(x => x.ProizvodID == model.proizvod.ProizvodID).FirstOrDefault();
                novi.BarKod = model.proizvod.BarKod;
                novi.CijenaBezPDV = model.CijenaBezPDVuKG * model.proizvod.Masa; // unos po kg a spasavanje po komadu
                novi.CijenaSaPDV = model.CijenaBezPDVuKG * model.proizvod.Masa + (model.CijenaBezPDVuKG * model.proizvod.Masa * 0.17);
                novi.Masa = model.proizvod.Masa;
                novi.Naziv = model.proizvod.Naziv;
                novi.SkladisteID = model.proizvod.SkladisteID;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            novi = new Proizvod
            {
                BarKod = model.proizvod.BarKod,
                CijenaBezPDV = model.CijenaBezPDVuKG * model.proizvod.Masa, // unos po kg a spasavanje po komadu,
                CijenaSaPDV = model.CijenaBezPDVuKG * model.proizvod.Masa + (model.CijenaBezPDVuKG * model.proizvod.Masa * 0.17),
            Masa = model.proizvod.Masa,
                Naziv = model.proizvod.Naziv,
                SkladisteID = model.proizvod.SkladisteID
            };


        _db.Proizvodi.Add(novi);
            _db.SaveChanges();
            return RedirectToAction("Index");
    }
    public IActionResult Obrisi(int ProizvodId)
    {
        _db.Proizvodi.Remove(_db.Proizvodi.Where(x => x.ProizvodID == ProizvodId).FirstOrDefault());
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Uredi(int ProizvodId)
    {
        ProizvodiDodajVM Model = new ProizvodiDodajVM();
        Model.proizvod = _db.Proizvodi.Where(x => x.ProizvodID == ProizvodId).FirstOrDefault();
        Model.listaSkladista = new List<SelectListItem>();
        Model.listaSkladista = _db.Skladiste.Select(x => new SelectListItem
        {
            Value = x.SkladisteID.ToString(),
            Text = x.VrstaKafe
        }).ToList();

            Model.CijenaBezPDVuKG = Model.proizvod.CijenaBezPDV / Model.proizvod.Masa;
        return View("Dodaj", Model);
    }
}
}