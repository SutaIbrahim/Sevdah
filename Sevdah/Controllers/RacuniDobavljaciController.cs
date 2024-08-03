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
    [Autorizacija(osoba: true)]

    public class RacuniDobavljaciController : Controller
    {

        DBContext db;
        public RacuniDobavljaciController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index(RacuniDobavljacaIndexVM podaci)
        {
            RacuniDobavljacaIndexVM model = new RacuniDobavljacaIndexVM();

            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {

                if (podaci.srchTxt == null)
                {
                    model.Racuni = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x => x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId).ToList();
                }
                else
                {
                    //tacan naziv ili broj racuna
                    model.Racuni = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x =>  x.Dobavljac.Naziv.StartsWith(podaci.srchTxt)|| x.BrojRacuna.StartsWith(podaci.srchTxt)).ToList();
                }

                model.listaGodina = new List<SelectListItem>();
                for (int i = 2018; i < 2100; i++)
                {
                    model.listaGodina.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
                }

                model.listaMjeseci = new List<SelectListItem>();
                model.listaMjeseci.Add(new SelectListItem { Value = 1.ToString(), Text = "Januar" });
                model.listaMjeseci.Add(new SelectListItem { Value = 2.ToString(), Text = "Februar" });
                model.listaMjeseci.Add(new SelectListItem { Value = 3.ToString(), Text = "Mart" });
                model.listaMjeseci.Add(new SelectListItem { Value = 4.ToString(), Text = "April" });
                model.listaMjeseci.Add(new SelectListItem { Value = 5.ToString(), Text = "Maj" });
                model.listaMjeseci.Add(new SelectListItem { Value = 6.ToString(), Text = "Juni" });
                model.listaMjeseci.Add(new SelectListItem { Value = 7.ToString(), Text = "Juli" });
                model.listaMjeseci.Add(new SelectListItem { Value = 8.ToString(), Text = "August" });
                model.listaMjeseci.Add(new SelectListItem { Value = 9.ToString(), Text = "Septembar" });
                model.listaMjeseci.Add(new SelectListItem { Value = 10.ToString(), Text = "Oktobar" });
                model.listaMjeseci.Add(new SelectListItem { Value = 11.ToString(), Text = "Novembar" });
                model.listaMjeseci.Add(new SelectListItem { Value = 12.ToString(), Text = "Decembar" });

                model.GodinaId = podaci.GodinaId;
                model.MjesecId = podaci.MjesecId;
                model.srchTxt = podaci.srchTxt;

                if (model.Racuni.Count != 0)
                {
                    //zadnji ID !!!!
                    model.zadnjiID = db.RacuniDobavljaca.Max(p => p.RacunDobavljacaID);
                    //
                }

                return View(model);
            }

            //else

            model.Racuni = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x => x.Datum.Month == DateTime.Now.Month && x.Datum.Year == DateTime.Now.Year).ToList();

            model.listaGodina = new List<SelectListItem>();
            for (int i = 2018; i < 2100; i++)
            {
                model.listaGodina.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            model.listaMjeseci = new List<SelectListItem>();
            model.listaMjeseci.Add(new SelectListItem { Value = 1.ToString(), Text = "Januar" });
            model.listaMjeseci.Add(new SelectListItem { Value = 2.ToString(), Text = "Februar" });
            model.listaMjeseci.Add(new SelectListItem { Value = 3.ToString(), Text = "Mart" });
            model.listaMjeseci.Add(new SelectListItem { Value = 4.ToString(), Text = "April" });
            model.listaMjeseci.Add(new SelectListItem { Value = 5.ToString(), Text = "Maj" });
            model.listaMjeseci.Add(new SelectListItem { Value = 6.ToString(), Text = "Juni" });
            model.listaMjeseci.Add(new SelectListItem { Value = 7.ToString(), Text = "Juli" });
            model.listaMjeseci.Add(new SelectListItem { Value = 8.ToString(), Text = "August" });
            model.listaMjeseci.Add(new SelectListItem { Value = 9.ToString(), Text = "Septembar" });
            model.listaMjeseci.Add(new SelectListItem { Value = 10.ToString(), Text = "Oktobar" });
            model.listaMjeseci.Add(new SelectListItem { Value = 11.ToString(), Text = "Novembar" });
            model.listaMjeseci.Add(new SelectListItem { Value = 12.ToString(), Text = "Decembar" });


            model.GodinaId = DateTime.Now.Year;
            model.MjesecId = DateTime.Now.Month;

            if (model.Racuni.Count != 0)
            {
                //zadnji ID
                model.zadnjiID = db.RacuniDobavljaca.Max(p => p.RacunDobavljacaID);
                //
            }

            return View(model);
        }

        public IActionResult Dodaj()
        {
            RacuniDobavljacaDodajVM model = new RacuniDobavljacaDodajVM();

            model.Dobavljaci = db.Dobavljaci.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.DobavljacID.ToString()
            }).ToList();

            return View(model);
        }

        public IActionResult Snimi(RacuniDobavljacaDodajVM model)
        {
            RacunDobavljaca racun = new RacunDobavljaca();

            racun.BrojRacuna = model.BrojRacuna;
            racun.DobavljacID = model.DobavljacID;
            racun.Datum = Convert.ToDateTime(model.Datum);
            racun.UkupnoBezPDV = 0;
            racun.UkupnoSaPDV = 0;
            racun.DosadPlaceno = 0;
            racun.Placeno = false;

            db.RacuniDobavljaca.Add(racun);
            db.SaveChanges();

            return RedirectToAction(nameof(Detalji), new { RacunId = racun.RacunDobavljacaID });
        }

        public IActionResult Detalji(int RacunId)
        {
            RacunDobavljaca racun = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x => x.RacunDobavljacaID == RacunId).FirstOrDefault();

            RacunDobavljacaDetaljiVM model = new RacunDobavljacaDetaljiVM();

            model.racun = racun;

            model.stavke = db.RacunProizvodDobavljaca.Include(p => p.VrstaProizvoda).Where(x => x.RacunDobavljacaID == racun.RacunDobavljacaID).ToList();


            if (racun.DosadPlaceno > 0)
            {
                //
                List<RacunDobavljaca> Racuni = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x => x.Datum.Month == DateTime.Now.Month || x.Datum.Month == (DateTime.Now.Month - 1)).ToList();

                if (Racuni.Count != 0)
                {
                    //zadnji ID
                    model.zadnjiID = db.RacuniDobavljaca.Max(p => p.RacunDobavljacaID);
                    //
                }
                //
            }
            return View(model);
        }

        public IActionResult DodajStavku(int RacunId)
        {

            RacunDobavljaca racun = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x => x.RacunDobavljacaID == RacunId).FirstOrDefault();

            RacunDobavljacaDodajStavkuVM model = new RacunDobavljacaDodajStavkuVM();


            model.proizvodi = new List<SelectListItem>();

            //model.proizvodi.Add(new SelectListItem()
            //{
            //    Value = null,
            //    Text = "Odaberite proizvod"
            //});

            model.proizvodi.AddRange(db.ProizvodDobavljac.Include(p => p.VrstaProizvoda).Where(x => x.DobavljacID == racun.Dobavljac.DobavljacID).Select(y => new SelectListItem
            {
                Text = y.VrstaProizvoda.Naziv,
                Value = y.VrstaProizvoda.VrstaProizvodaID.ToString()
            }).ToList());



            model.stavka = new RacunProizvodDobavljaca();
            model.stavka.RacunDobavljacaID = RacunId;

            return View(model);
        }

        public IActionResult SnimiStavku(RacunDobavljacaDodajStavkuVM model)
        {

            RacunProizvodDobavljaca stavka = model.stavka;

            stavka.IznosSaPDV = Math.Round(model.stavka.IznosSaPDV, 4);

            stavka.IznosBezPDV = Math.Round(model.stavka.IznosSaPDV * 0.83, 4);

            db.RacunProizvodDobavljaca.Add(stavka);
            db.SaveChanges();

            //

            RacunDobavljaca racun = db.RacuniDobavljaca.Include(p => p.Dobavljac).Where(x => x.RacunDobavljacaID == stavka.RacunDobavljacaID).FirstOrDefault();

            racun.UkupnoBezPDV += stavka.IznosBezPDV;
            racun.UkupnoSaPDV += stavka.IznosSaPDV;

            // regulisanje kredita pri dodavanju stavki

            Dobavljac dobavljac = db.Dobavljaci.Where(x => x.DobavljacID == racun.DobavljacID).FirstOrDefault();

            double kredit = (double)dobavljac.Kredit;

            if (kredit != 0)
            {
                double potrebno = racun.UkupnoSaPDV - racun.DosadPlaceno;

                if (kredit <= potrebno)
                {
                    racun.DosadPlaceno += kredit;
                    dobavljac.Kredit = 0;

                }
                else
                {
                    dobavljac.Kredit -= potrebno;
                    racun.DosadPlaceno += potrebno;
                }

                if (racun.UkupnoSaPDV <= racun.DosadPlaceno)
                {
                    racun.Placeno = true;
                }
                else
                {
                    racun.Placeno = false;
                }

                db.Dobavljaci.Update(dobavljac);
            }

            //

            db.RacuniDobavljaca.Update(racun);
            db.SaveChanges();

            return RedirectToAction(nameof(Detalji), new { RacunId = model.stavka.RacunDobavljacaID });
        }

        public IActionResult ObrisiStavku(int StavkaId)
        {
            RacunProizvodDobavljaca stavka = db.RacunProizvodDobavljaca.Where(x => x.RacunProizvodDobavljacaID == StavkaId).FirstOrDefault();

            RacunDobavljaca racun = db.RacuniDobavljaca.Where(x => x.RacunDobavljacaID == stavka.RacunDobavljacaID).FirstOrDefault();

            racun.UkupnoBezPDV -= stavka.IznosBezPDV;
            racun.UkupnoSaPDV -= stavka.IznosSaPDV;

            db.RacuniDobavljaca.Update(racun);
            db.RacunProizvodDobavljaca.Remove(stavka);
            db.SaveChanges();

            return RedirectToAction(nameof(Detalji), new { RacunId = racun.RacunDobavljacaID });
        }

        public IActionResult Obrisi(int RacunId)
        {
            RacunDobavljaca racun = db.RacuniDobavljaca.Where(x => x.RacunDobavljacaID == RacunId).FirstOrDefault();

            if (racun.DosadPlaceno > 0)
            {
                Dobavljac dobavljac = db.Dobavljaci.Where(x => x.DobavljacID == racun.DobavljacID).FirstOrDefault();

                dobavljac.Kredit += racun.DosadPlaceno;

                db.Dobavljaci.Update(dobavljac);
                db.SaveChanges();
            }

            List<RacunProizvodDobavljaca> stavke = db.RacunProizvodDobavljaca.Where(x => x.RacunDobavljacaID == RacunId).ToList();

            if (stavke != null)
            {
                foreach(var x in stavke)
                {
                    db.RacunProizvodDobavljaca.Remove(x);
                    db.SaveChanges();
                }
            }

            db.RacuniDobavljaca.Remove(racun);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}