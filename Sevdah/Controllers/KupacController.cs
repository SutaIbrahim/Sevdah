using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sevdah.ViewModel;
using Sevdah.Models;
using Sevdah.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Helpers;

namespace Sevdah.Controllers
{
    [Autorizacija(osoba: true)]
    public class KupacController : Controller
    {
        DBContext db;

        public KupacController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {

            KupacIndexVM model = new KupacIndexVM();

            model.Kupci = db.Kupci.Include(x => x.Grad).Where(p => p.NazivKupca != "---").Select(y => new KupacIndexVM.Row()
            {
                KupacID = y.KupacID,
                NazivKupca = y.NazivKupca,
                ID_broj = y.ID_broj,
                PDV_broj = y.PDV_broj,
                Adresa = y.Adresa,
                Grad = y.Grad.Naziv,
                Kredit = y.Kredit,
                //Dugovanje = (db.Racuni.Where(t => t.KupacID == y.KupacID && t.Placeno==false).Sum(p => p.UkupnoZaNaplatu)) - (db.Racuni.Where(t => t.KupacID == y.KupacID && t.Placeno == false).Sum(p => p.DosadPlaceno)) - (db.Uplate.Where(r => r.KupacID == y.KupacID).Sum(e => e.Iznos)) 

            }).ToList();

            return View(model);
        }

        public IActionResult Pretraga(string srchTxt)
        {
            if (srchTxt == null)
                return RedirectToAction(nameof(Index));

            srchTxt = srchTxt.ToLower();

            KupacIndexVM model = new KupacIndexVM();
            model.Kupci = db.Kupci.Include(x => x.Grad).Where(y => y.NazivKupca.ToLower().Contains(srchTxt)).Select(y => new KupacIndexVM.Row()
            {
                KupacID = y.KupacID,
                NazivKupca = y.NazivKupca,
                ID_broj = y.ID_broj,
                PDV_broj = y.PDV_broj,
                Adresa = y.Adresa,
                Grad = y.Grad.Naziv,
                Kredit = y.Kredit,
                //Dugovanje = db.Racuni.Where(t => t.KupacID == y.KupacID).Sum(p => p.UkupnoZaNaplatu) - db.Uplate.Where(r => r.KupacID == y.KupacID).Sum(e => e.Iznos)

            }).ToList();

            model.srchTxt = srchTxt;

            return View("Index", model);
        }

        public IActionResult Dodaj()
        {
            KupacDodajVM model = new KupacDodajVM();

            model.Kupac = new Kupac();


            model.gradovi = db.Gradovi.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.GradID.ToString()
            }).ToList();


            return View(model);
        }


        public IActionResult Uredi(int KupacId)
        {
            Kupac Kupac = db.Kupci.Where(x => x.KupacID == KupacId).FirstOrDefault();

            KupacDodajVM model = new KupacDodajVM();

            model.Kupac = Kupac;

            model.gradovi = db.Gradovi.Select(x => new SelectListItem
            {

                Text = x.Naziv,
                Value = x.GradID.ToString()

            }).ToList();


            return View(model);

        }

        public IActionResult Snimi(KupacDodajVM model)
        {
            if (!ModelState.IsValid)
            {
                KupacDodajVM model2 = new KupacDodajVM();

                model2.Kupac = model.Kupac;
                model2.gradovi = db.Gradovi.Select(x => new SelectListItem
                {

                    Text = x.Naziv,
                    Value = x.GradID.ToString()

                }).ToList();

                return View("Dodaj", model2);

            }

            model.Kupac.Kredit = 0; // dodano 21.6

            Kupac kupac = model.Kupac;

            // kupac.Kredit = 0;

            db.Kupci.Add(kupac);

            db.SaveChanges();

            //
            // kreiranje rabata za kupca i sve proizvode

            var proizvodi = db.Proizvodi.ToList();

            foreach (var x in proizvodi)
            {

                OdobreniRabat rabat = new OdobreniRabat();

                rabat.KupacID = kupac.KupacID;
                rabat.ProizvodID = x.ProizvodID;

                rabat.IznosPostotci = 0;
                db.OdobreniRabat.Add(rabat);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SnimiUredi(KupacDodajVM model)
        {
            if (!ModelState.IsValid)
            {

                KupacDodajVM model2 = new KupacDodajVM();

                model2.Kupac = model.Kupac;
                model2.gradovi = db.Gradovi.Select(x => new SelectListItem
                {

                    Text = x.Naziv,
                    Value = x.GradID.ToString()

                }).ToList();

                return View("Uredi", model2);
            }


            Kupac edit;
            edit = db.Kupci.Where(x => x.KupacID == model.Kupac.KupacID).FirstOrDefault();

            edit.GradID = model.Kupac.GradID;
            edit.ID_broj = model.Kupac.ID_broj;
            edit.PDV_broj = model.Kupac.PDV_broj;
            edit.NazivKupca = model.Kupac.NazivKupca;
            edit.Adresa = model.Kupac.Adresa;
            edit.Kredit = model.Kupac.Kredit;

            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Obrisi(int KupacID)
        {
            Kupac kupac = db.Kupci.Where(x => x.KupacID == KupacID).FirstOrDefault();

            db.Kupci.Remove(kupac);
            db.SaveChanges();


            var rabati = db.OdobreniRabat.Where(x => x.KupacID == KupacID).ToList();


            foreach (var x in rabati)
            {
                db.OdobreniRabat.Remove(x);
                db.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult NapraviKontoKarticu(int KupacID)
        {
            KupacNapraviKontoKarticuVM Model = new KupacNapraviKontoKarticuVM();
            Model.datumOd = DateTime.Now.AddDays(-31);
            Model.datumDo = DateTime.Now;
            Model.KupacID = KupacID;

            Model.Grad = db.Kupci.Where(x => x.KupacID == KupacID).Include(p => p.Grad).FirstOrDefault().Grad.Naziv;
            return View(Model);
        }
        public IActionResult PrikaziKontoKarticu(KupacNapraviKontoKarticuVM model)
        {
            List<Racun> listaRacunaDb = new List<Racun>();
            List<Uplata> listaUplataDb = new List<Uplata>();


            //prethodno stanje !
            List<Racun> listaRacunaDbPRE = new List<Racun>();
            List<Uplata> listaUplataDbPRE = new List<Uplata>();

            double dugPRE = 0;
            double uplataPRE = 0;
            DateTime pocetnoStanjeAplikacije = new DateTime(2018, 7, 25); // na taj dan uneseni svi dugovi

            if (model.KupacID == 20 || model.KupacID == 23) // u slucaju da se izdaje konto kartica za Bingo jer u bazi imaju 2 binga ( sjever i jug )
            {
                //PRETHODNO DUGOVANJE
                listaRacunaDbPRE = db.Racuni.Include(x => x.Kupac).Where(x => (x.Datum >= pocetnoStanjeAplikacije && x.Datum < model.datumOd) && (x.KupacID == 20 || x.KupacID == 23)).ToList();

                listaUplataDbPRE = db.Uplate.Include(x => x.Kupac).Where(x => (x.Datum >= pocetnoStanjeAplikacije && x.Datum < model.datumOd) && (x.KupacID == 20 || x.KupacID == 23)).ToList();

                for (int i = 0; i < listaRacunaDbPRE.Count(); i++)
                {
                    dugPRE += listaRacunaDbPRE[i].UkupnoBezPDV + (listaRacunaDbPRE[i].UkupnoBezPDV * 0.17);
                }
                for (int i = 0; i < listaUplataDbPRE.Count(); i++)
                {
                    uplataPRE += listaUplataDbPRE[i].Iznos;
                }
                //

                listaRacunaDb = db.Racuni.Include(x => x.Kupac).Where(x => (x.Datum >= model.datumOd && x.Datum <= model.datumDo.AddHours(8)) && (x.KupacID == 20 || x.KupacID==23)).ToList();

                listaUplataDb = db.Uplate.Include(x => x.Kupac).Where(x => (x.Datum >= model.datumOd && x.Datum <= model.datumDo.AddHours(8)) && (x.KupacID == 20 || x.KupacID == 23)).ToList();
            }
            else
            {
                //PRETHODNO DUGOVANJE
                listaRacunaDbPRE = db.Racuni.Include(x => x.Kupac).Where(x => ( x.Datum>=pocetnoStanjeAplikacije &&x.Datum < model.datumOd) && x.KupacID == model.KupacID).ToList();

                listaUplataDbPRE = db.Uplate.Include(x => x.Kupac).Where(x => (x.Datum >= pocetnoStanjeAplikacije && x.Datum < model.datumOd) && x.KupacID == model.KupacID).ToList();

                for(int i = 0; i < listaRacunaDbPRE.Count(); i++)
                {
                    dugPRE += listaRacunaDbPRE[i].UkupnoBezPDV + (listaRacunaDbPRE[i].UkupnoBezPDV*0.17); 
                }
                for(int i = 0; i < listaUplataDbPRE.Count(); i++)
                {
                    uplataPRE += listaUplataDbPRE[i].Iznos;
                }
                //


                listaRacunaDb = db.Racuni.Include(x => x.Kupac).Where(x => (x.Datum >= model.datumOd && x.Datum <= model.datumDo.AddHours(8)) && x.KupacID == model.KupacID).ToList();

                listaUplataDb = db.Uplate.Include(x => x.Kupac).Where(x => (x.Datum >= model.datumOd && x.Datum <= model.datumDo.AddHours(8)) && x.KupacID == model.KupacID).ToList();
            }



            KupacKontoKartica Model = new KupacKontoKartica();
            Model.DatumOd = model.datumOd;
            Model.DatumDo = model.datumDo;
            Model.KupacId = model.KupacID;
            Model.Grad = model.Grad;
            Model.redovi = new List<KupacKontoKartica.Row>();
            Model.Saldo = 0;

            Model.prethodnoDugovanje = uplataPRE - dugPRE;

            ////dodavanje prvog reda, tj prethodnog stanja prije izabranog datuma
            //Model.redovi.Add(new KupacKontoKartica.Row
            //{
            //    Datum = model.datumOd,
            //    Duguje = dugPRE,
            //    Potrazuje = uplataPRE,
            //    Saldo = uplataPRE - dugPRE,
            //    VezniDokument = "Prethodno stanje"

            //});

            for (int i = 0; i < listaRacunaDb.Count(); i++)
            {
                Model.redovi.Add(new KupacKontoKartica.Row
                {
                    Datum = listaRacunaDb[i].Datum,
                    Duguje = listaRacunaDb[i].UkupnoBezPDV + (listaRacunaDb[i].UkupnoBezPDV * 0.17),
                    Potrazuje = 0,
                    Saldo = 0,
                    VezniDokument = listaRacunaDb[i].BrojRacuna
                });
            }
            for (int i = 0; i < listaUplataDb.Count(); i++)
            {
                Model.redovi.Add(new KupacKontoKartica.Row
                {
                    Datum = listaUplataDb[i].Datum,
                    Duguje = 0,
                    Potrazuje = listaUplataDb[i].Iznos,
                    Saldo = 0,
                    VezniDokument = listaUplataDb[i].BrojIzvoda
                });
            }
            Model.redovi = Model.redovi.OrderBy(x => x.Datum).ToList();

            for (int i = 0; i < Model.redovi.Count; i++)
            {
                Model.SumaDuguje += Model.redovi[i].Duguje;
                Model.SumaPotrazuje += Model.redovi[i].Potrazuje;
                if (i == 0)
                {
                    Model.redovi[i].Saldo = Model.redovi[i].Potrazuje - Model.redovi[i].Duguje;
                }
                else
                {
                    Model.redovi[i].Saldo = Model.redovi[i - 1].Saldo + (Model.redovi[i].Potrazuje - Model.redovi[i].Duguje);
                }
            }

            KontoKupacReport novi = new KontoKupacReport();

            Model.NazivKupca = db.Kupci.Where(x => x.KupacID == model.KupacID).FirstOrDefault().NazivKupca;
            Model.AdresaKupca = db.Kupci.Where(x => x.KupacID == model.KupacID).FirstOrDefault().Adresa;
            Model.Saldo = Model.SumaPotrazuje - Model.SumaDuguje;

            byte[] docArray = novi.PrepareReport(Model);
            return File(docArray, "application/pdf");

        }



    }
}