using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;
using Sevdah.ViewModel;

namespace Sevdah.Controllers
{
    public class OtpremniceController : Controller
    {

        DBContext db;

        public OtpremniceController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index(OtpremniceIndexVM podaci)
        {
            OtpremniceIndexVM model = new OtpremniceIndexVM();



            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {
                model.Otpremnice = db.Otpremnica.Include(p => p.Kupac).Where(x => x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId).ToList();

                model.listaGodina = new List<SelectListItem>();
                for (int i = 2018; i < 2030; i++)
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


                if (model.Otpremnice.Count != 0)
                {
                    //zadnji ID !!!!
                    model.zadnjiID = db.Otpremnica.Max(p => p.OtpremnicaID);
                    //
                }

                return View(model);
            }

            //else

            model.Otpremnice = db.Otpremnica.Include(p => p.Kupac).Where(x => x.Datum.Month == DateTime.Now.Month && x.Datum.Year == DateTime.Now.Year).ToList();

            model.listaGodina = new List<SelectListItem>();
            for (int i = 2018; i < 2030; i++)
            {
                model.listaGodina.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
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


            if (model.Otpremnice.Count != 0)
            {
                //zadnji ID
                model.zadnjiID = db.Otpremnica.Max(p => p.OtpremnicaID);
                //
            }

            return View(model);
        }

        public IActionResult Dodaj()
        {
            OtpremnicaDodajVM model = new OtpremnicaDodajVM();

            model.Kupci = db.Kupci.Select(x => new SelectListItem
            {
                Text = x.NazivKupca,
                Value = x.KupacID.ToString()
            }).ToList();

            model.Revers = false;

            return View(model);

        }

        public IActionResult Snimi(OtpremnicaDodajVM model)
        {
            Otpremnica otpremnica = new Otpremnica();

            otpremnica.KupacID = model.KupacID;
            otpremnica.Datum = DateTime.Now;
            otpremnica.Revers = model.Revers;

            db.Otpremnica.Add(otpremnica);
            db.SaveChanges();

            return RedirectToAction(nameof(Detalji), new { OtpremnicaId = otpremnica.OtpremnicaID });
        }

        public IActionResult Detalji(int OtpremnicaId)
        {
            Otpremnica otpremnica = db.Otpremnica.Include(p => p.Kupac).Where(x => x.OtpremnicaID == OtpremnicaId).FirstOrDefault();


           OtpremnicaDetaljiVM model = new OtpremnicaDetaljiVM();

            model.otpremnica = otpremnica;

            model.stavke = db.OtpremnicaProizvod.Include(p=>p.Proizvod).Where(x => x.OtpremnicaID == otpremnica.OtpremnicaID).ToList();


            return View(model);
        }

        public IActionResult DodajStavku(int OtpremnicaId)
        {

            Otpremnica otpremnica = db.Otpremnica.Include(p => p.Kupac).Where(x => x.OtpremnicaID == OtpremnicaId).FirstOrDefault();

            OtpremnicaDodajStavkuVM model = new OtpremnicaDodajStavkuVM();


            model.proizvodi = new List<SelectListItem>();

            //model.proizvodi.Add(new SelectListItem()
            //{
            //    Value = null,
            //    Text = "Odaberite proizvod"
            //});

            model.proizvodi.AddRange(db.Proizvodi.Select(y => new SelectListItem
            {
                Text = y.Naziv,
                Value = y.ProizvodID.ToString()
            }).ToList());



            model.stavka = new OtpremnicaProizvod();
            model.stavka.OtpremnicaID = OtpremnicaId;

            return View(model);
        }

        public IActionResult SnimiStavku(OtpremnicaDodajStavkuVM model)
        {

            OtpremnicaProizvod stavka = model.stavka;

            db.OtpremnicaProizvod.Add(stavka);
            db.SaveChanges();

            return RedirectToAction(nameof(Detalji), new { OtpremnicaId = model.stavka.OtpremnicaID });
        }

        public IActionResult ObrisiStavku(int StavkaId)
        {
            OtpremnicaProizvod stavka = db.OtpremnicaProizvod.Where(x => x.OtpremnicaProizvodID == StavkaId).FirstOrDefault();

            db.OtpremnicaProizvod.Remove(stavka);
            db.SaveChanges();

            return RedirectToAction(nameof(Detalji), new { OtpremnicaId = stavka.OtpremnicaID });
        }

        public IActionResult Obrisi(int OtpremnicaId)
        {
            Otpremnica otpremnica = db.Otpremnica.Where(x => x.OtpremnicaID == OtpremnicaId).FirstOrDefault();

            List<OtpremnicaProizvod> stavke = db.OtpremnicaProizvod.Where(x => x.OtpremnicaID == OtpremnicaId).ToList();

            if (stavke != null)
            {
                foreach (var x in stavke)
                {
                    db.OtpremnicaProizvod.Remove(x);
                    db.SaveChanges();
                }
            }

            db.Otpremnica.Remove(otpremnica);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult PrintajOtpremnicu(int OtpremnicaId,int KupacId)
        {
            OtpremnicaReportVM Model = new OtpremnicaReportVM();
            Model._kupac = new Kupac();
            Model._kupac = db.Kupci.Where(x => x.KupacID == KupacId).Include(x=>x.Grad).FirstOrDefault();
            Model._otpremnica = new Otpremnica();
            Model._otpremnica = db.Otpremnica.Where(x => x.OtpremnicaID == OtpremnicaId).Include(x=>x.Kupac).FirstOrDefault();
            Model._listaStavki = new List<OtpremnicaProizvod>();
            Model._listaStavki = db.OtpremnicaProizvod.Where(x => x.OtpremnicaID == OtpremnicaId).Include(x=>x.Otpremnica).Include(x=>x.Proizvod).ToList();

            OtpremnicaReport novaOtpremnica = new OtpremnicaReport();
            byte[] otpremnicaPdf = novaOtpremnica.PrepareReport(Model);
            return File(otpremnicaPdf, "application/pdf");

        }
    }
}