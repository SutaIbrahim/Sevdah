using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;
using Sevdah.ViewModel;

namespace Sevdah.Controllers
{
    public class PredracuniController : Controller
    {
        private DBContext _db;

        public PredracuniController(DBContext db)
        {
            _db = db;
        }

        public IActionResult Index(RacuniIndexVM podaci)
        {
            RacuniIndexVM Model = new RacuniIndexVM();

            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {
                Model.listaRacuna = new List<RacuniIndexVM.Row>();

                if (podaci.srchTxt == null)
                {
                    Model.listaRacuna = _db.Racuni.Include(x => x.Kupac).Where(x => (x.IsPredracun == true && x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId)).Select(x => new RacuniIndexVM.Row
                    {
                        RacunId = x.RacunID,
                        BrojRacuna = x.BrojRacuna,
                        DatumIzdavanja = x.Datum,
                        DoSadaPlaceno = x.DosadPlaceno,
                        Kupac = x.Kupac.NazivKupca,
                        UkupnoZaNaplatu = x.UkupnoBezPDV + (x.UkupnoBezPDV * x.PDV),
                        Placeno = x.Placeno
                    }).ToList();
                }
                else
                {
                    podaci.srchTxt = podaci.srchTxt.ToLower();

                    Model.listaRacuna = _db.Racuni.OrderBy(d => d.Datum).Include(x => x.Kupac).Where(x => (x.IsPredracun == true && x.Kupac.NazivKupca.ToLower().Contains(podaci.srchTxt) || x.BrojRacuna.StartsWith(podaci.srchTxt))).Select(x => new RacuniIndexVM.Row
                    {
                        RacunId = x.RacunID,
                        BrojRacuna = x.BrojRacuna,
                        DatumIzdavanja = x.Datum,
                        DoSadaPlaceno = x.DosadPlaceno,
                        Kupac = x.Kupac.NazivKupca,
                        UkupnoZaNaplatu = x.UkupnoBezPDV + (x.UkupnoBezPDV * x.PDV),
                        Placeno = x.Placeno
                    }).ToList();
                }

                Model.listaGodina = new List<SelectListItem>();
                for (int i = 2018; i < 2050; i++)
                {
                    Model.listaGodina.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
                }

                Model.listaMjeseci = new List<SelectListItem>();
                Model.listaMjeseci.Add(new SelectListItem { Value = 1.ToString(), Text = "Januar" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 2.ToString(), Text = "Februar" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 3.ToString(), Text = "Mart" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 4.ToString(), Text = "April" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 5.ToString(), Text = "Maj" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 6.ToString(), Text = "Juni" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 7.ToString(), Text = "Juli" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 8.ToString(), Text = "August" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 9.ToString(), Text = "Septembar" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 10.ToString(), Text = "Oktobar" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 11.ToString(), Text = "Novembar" });
                Model.listaMjeseci.Add(new SelectListItem { Value = 12.ToString(), Text = "Decembar" });

                Model.GodinaId = podaci.GodinaId;
                Model.MjesecId = podaci.MjesecId;
                Model.srchTxt = podaci.srchTxt;

                if (Model.listaRacuna.Count != 0)
                {
                    //zadnji ID !!!!
                    Model.zadnjiID = _db.Racuni.Where(x => x.IsPredracun).Max(p => p.RacunID);
                    //
                }

                return View(Model);
            }

            //else

            Model = new RacuniIndexVM();
            Model.listaRacuna = new List<RacuniIndexVM.Row>();
            Model.listaRacuna = _db.Racuni.Where(x => x.IsPredracun == true && (x.Datum.Month == DateTime.Now.Month) && (x.Datum.Year == DateTime.Now.Year)).Select(x => new RacuniIndexVM.Row
            {
                RacunId = x.RacunID,
                BrojRacuna = x.BrojRacuna,
                DatumIzdavanja = x.Datum,
                DoSadaPlaceno = x.DosadPlaceno,
                Kupac = x.Kupac.NazivKupca,
                UkupnoZaNaplatu = x.UkupnoBezPDV + (x.UkupnoBezPDV * x.PDV),
                Placeno = x.Placeno
            }).ToList();

            Model.listaGodina = new List<SelectListItem>();
            for (int i = 2018; i < 2050; i++)
            {
                Model.listaGodina.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            Model.listaMjeseci = new List<SelectListItem>();
            Model.listaMjeseci.Add(new SelectListItem { Value = 1.ToString(), Text = "Januar" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 2.ToString(), Text = "Februar" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 3.ToString(), Text = "Mart" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 4.ToString(), Text = "April" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 5.ToString(), Text = "Maj" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 6.ToString(), Text = "Juni" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 7.ToString(), Text = "Juli" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 8.ToString(), Text = "August" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 9.ToString(), Text = "Septembar" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 10.ToString(), Text = "Oktobar" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 11.ToString(), Text = "Novembar" });
            Model.listaMjeseci.Add(new SelectListItem { Value = 12.ToString(), Text = "Decembar" });

            Model.GodinaId = DateTime.Now.Year;
            Model.MjesecId = DateTime.Now.Month;

            if (Model.listaRacuna.Count != 0)
            {
                //zadnji ID !!!!
                Model.zadnjiID = _db.Racuni.Where(x => x.IsPredracun).Max(p => p.RacunID);
                //
            }

            return View(Model);
        }
        public IActionResult Dodaj()
        {
            RacuniDodajVM Model = new RacuniDodajVM();
            Model.racun = new Models.Racun();
            Model.listaKupaca = new List<SelectListItem>();
            Model.listaKupaca = _db.Kupci.Select(x => new SelectListItem
            {
                Value = x.KupacID.ToString(),
                Text = x.NazivKupca
            }).ToList();

            return View(Model);
        }
        public IActionResult Snimi(RacuniDodajVM model)
        {
            Racun novi = new Racun
            {
                BrojRacuna = (_db.Racuni.Include(x => x.Kupac).Where(x => (x.IsPredracun == true && x.Datum.Year == DateTime.Now.Year)).ToList().Count + 1).ToString() + "/" + DateTime.Now.Year.ToString().Substring(2, 2),
                Datum = DateTime.Now,
                DosadPlaceno = 0,
                KupacID = model.racun.KupacID,
                PDV = (float)0.17,
                UkupnoZaNaplatu = 0,
                UkupnoBezPDV = 0,
                Placeno = false,
                BrojFiskalnogRacuna = string.Empty,
                IsPredracun = true
            };

            _db.Racuni.Add(novi);
            _db.SaveChanges();

            return RedirectToAction("Uredi", new { RacunId = novi.RacunID });
        }
        public IActionResult Uredi(int RacunId)
        {
            RacuniUrediVM Model = new RacuniUrediVM();
            Model.racun = _db.Racuni.Include(x => x.Kupac).Where(x => x.RacunID == RacunId).FirstOrDefault();
            Model.listaStavki = new List<RacunProizvod>();
            Model.listaStavki = _db.RacunProizvodi.Include(x => x.Proizvod).Where(x => x.RacunID == RacunId).ToList();

            return View(Model);
        }
        public IActionResult DodajStavku(int RacunId)
        {
            RacuniDodajStavkuVM Model = new RacuniDodajStavkuVM();
            Model.listaProizvoda = new List<SelectListItem>();
            Model.listaProizvoda = _db.Proizvodi.Select(x => new SelectListItem
            {
                Value = x.ProizvodID.ToString(),
                Text = x.Naziv
            }).ToList();

            Model.stavka = new RacunProizvod();
            Model.RacunId = RacunId;
            Model.KupacId = _db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault().KupacID;

            Model.Rabati = _db.OdobreniRabat.Include(x => x.Proizvod).Where(p => p.KupacID == Model.KupacId).ToList();
            Model.Kupac = _db.Kupci.Where(x => x.KupacID == Model.KupacId).FirstOrDefault().NazivKupca;

            return View(Model);
        }
        public IActionResult SnimiStavku(RacuniDodajStavkuVM model)
        {
            Kupac k = _db.Kupci.Where(x => x.KupacID == model.KupacId).FirstOrDefault();
            Racun r = _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault();

            //model.komada predstavlja kolicinu u KG
            RacunProizvod pronadjena = _db.RacunProizvodi.Where(x => x.RacunID == model.RacunId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault();
            if (pronadjena != null)
            {
                Proizvod proizvodStavka = _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault();
                pronadjena.KolicinaKG += model.komada;
                pronadjena.IznosRabata += Math.Round((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100), 4);
                pronadjena.IznosBezPDV += Math.Round(((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV) - ((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100)), 4);
                _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault().UkupnoBezPDV += Math.Round(((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV) - ((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100)), 4);
                _db.SaveChanges();

                _db.SaveChanges();

                return RedirectToAction("Uredi", new { RacunId = model.RacunId });
            }

            RacunProizvod novaStavka = new RacunProizvod
            {
                CijenaBezPDV = _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().CijenaBezPDV, // promijenjeno 21.6, bilo stavljene 4 decimale
                RacunID = model.RacunId,
                ProizvodID = model.stavka.ProizvodID,
                KolicinaKG = model.komada
            };

            if (_db.OdobreniRabat.Where(x => x.KupacID == model.KupacId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault() == null)
            {
                novaStavka.Rabat = 0;
            }
            else
            {
                novaStavka.Rabat = _db.OdobreniRabat.Where(x => x.KupacID == model.KupacId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().IznosPostotci;
            }

            novaStavka.IznosRabata = Math.Round((model.komada / _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().Masa) * _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().CijenaBezPDV * (novaStavka.Rabat / 100), 4);
            novaStavka.IznosBezPDV = Math.Round((model.komada / _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().Masa) * _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().CijenaBezPDV - novaStavka.IznosRabata, 4);

            _db.RacunProizvodi.Add(novaStavka);
            _db.SaveChanges();
            _db.SaveChanges();
            _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault().UkupnoBezPDV += Math.Round(novaStavka.IznosBezPDV, 4);
            _db.SaveChanges();

            return RedirectToAction("Uredi", new { RacunId = model.RacunId });
        }
        public IActionResult Obrisi(int RacunProizvodId, int RacunId)
        {
            RacunProizvod stavka = _db.RacunProizvodi.Where(x => x.RacunProizvodID == RacunProizvodId).FirstOrDefault();

            Racun r = _db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault();
            _db.Kupci.Where(x => x.KupacID == r.KupacID).FirstOrDefault().Kredit += stavka.IznosBezPDV + (stavka.IznosBezPDV * r.PDV);

            _db.Racuni.Where(x => x.RacunID == stavka.RacunID).FirstOrDefault().UkupnoBezPDV -= stavka.IznosBezPDV;
            _db.RacunProizvodi.Remove(stavka);
            _db.SaveChanges();
            return RedirectToAction("Uredi", new { RacunId = RacunId });
        }

        public IActionResult ObrisiPredRacun(int RacunId)
        {
            Racun r = _db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault();
            List<RacunProizvod> listaStavki = _db.RacunProizvodi.Where(x => x.RacunID == RacunId).ToList();

            _db.RacunProizvodi.RemoveRange(listaStavki);
            _db.SaveChanges();
            _db.Racuni.Remove(_db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault());
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PrikaziPredracunDokument(int RacunId)
        {
            byte[] docArray;
            RacuniReportVM Model = new RacuniReportVM();
            PredracunReport report = new PredracunReport();
            Model.racun = _db.Racuni.Where(x => x.RacunID == RacunId).Include(x => x.Kupac).ThenInclude(x => x.Grad).FirstOrDefault();
            Model.listaStavki = new List<RacunProizvod>();
            Model.listaStavki = _db.RacunProizvodi.Include(x => x.Proizvod).Include(x => x.Racun).Where(x => x.RacunID == RacunId).ToList();
            docArray = report.PrepareReport(Model);
            return File(docArray, "application/pdf");
        }

    }
}