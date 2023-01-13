using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sevdah.ViewModel;
using Sevdah.Data;
using Microsoft.EntityFrameworkCore;
using Sevdah.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Helpers;

namespace Sevdah.Controllers
{
    [Autorizacija(osoba: true)]

    public class UplateController : Controller
    {

        DBContext db;

        public UplateController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index(UplateIndexVM podaci)
        {
            UplateIndexVM model = new UplateIndexVM();

            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {

                if (podaci.srchTxt == null)
                {
                    model.Uplate = db.Uplate.Include(p => p.Kupac).Where(x => x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId).ToList();
                }
                else
                {
                    // tacan naziv ili broj izvoda
                    model.Uplate = db.Uplate.Include(p => p.Kupac).Include(z => z.Kupac).Where(x => (x.Kupac.NazivKupca.StartsWith(podaci.srchTxt) || x.BrojIzvoda.StartsWith(podaci.srchTxt))).ToList();
                }

                model.listaGodina = new List<SelectListItem>();
                for (int i = 2018; i < 2050; i++)
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

                return View(model);

            }

            //else

            model.Uplate = db.Uplate.Include(x => x.Kupac).Where(x => x.Datum.Month == DateTime.Now.Month && x.Datum.Year == DateTime.Now.Year).ToList();

            model.listaGodina = new List<SelectListItem>();
            for (int i = 2018; i < 2050; i++)
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


            return View(model);
        }

        //public IActionResult Pretraga(string srchTxt)
        //{
        //    if (srchTxt == null)
        //        return RedirectToAction(nameof(Index));


        //    UplateIndexVM model = new UplateIndexVM();
        //    model.Uplate = db.Uplate.Include(x => x.Kupac).Where(y => y.Kupac.NazivKupca.StartsWith(srchTxt) || y.BrojIzvoda.StartsWith(srchTxt)).ToList();
        //    model.srchTxt = srchTxt;

        //    return View("Index", model);
        //}

        public IActionResult Dodaj(int KupacID)
        {
            UplateDodajVM model = new UplateDodajVM();

            model.KupacID = KupacID;

            model.NazivKupca = db.Kupci.Where(x => x.KupacID == KupacID).FirstOrDefault().NazivKupca;

            model.IznosUplate = 0;

            model.Dodaj = true;

            model.BrojIzvoda = "";

            return View(model);
        }

        public IActionResult Snimi(UplateDodajVM model)
        {
            if (model.Dodaj == true)
            {
                Uplata nova = new Uplata();

                nova.Iznos = model.IznosUplate;
                nova.KupacID = model.KupacID;
                nova.Datum = model.Datum;
                nova.BrojIzvoda = model.BrojIzvoda;

                db.Uplate.Add(nova);
                db.SaveChanges();


                // regulisanje prema racunima

                double NoviIznos = Math.Round(model.IznosUplate, 2);

                List<Racun> racuni = db.Racuni.Where(x => x.Placeno == false && x.KupacID == nova.KupacID).ToList();

                foreach (var x in racuni)
                {


                    double DosadPlaceno = x.DosadPlaceno;
                    double IznosRacuna = x.UkupnoBezPDV + (x.UkupnoBezPDV * x.PDV); // ukupno za naplatu

                    double potrebno = Math.Round(IznosRacuna - DosadPlaceno, 4);

                    if (NoviIznos >= potrebno)
                    {
                        NoviIznos -= potrebno;
                        x.DosadPlaceno = Math.Round(x.DosadPlaceno, 4) + potrebno;
                        x.Placeno = true;
                    }
                    else
                    {
                        x.DosadPlaceno = Math.Round(x.DosadPlaceno, 2) + NoviIznos;
                        NoviIznos = 0;
                    }

                    if (Math.Round(x.DosadPlaceno, 4) == Math.Round(IznosRacuna, 4))
                    {
                        x.Placeno = true;
                    }

                    if (NoviIznos == 0)
                    {
                        db.Racuni.Update(x);
                        db.SaveChanges();

                        break;
                    }

                    db.Racuni.Update(x);
                    db.SaveChanges();

                }

                if (NoviIznos > 0)
                {
                    Kupac kupac = db.Kupci.Where(x => x.KupacID == model.KupacID).FirstOrDefault();
                    kupac.Kredit += Math.Round(NoviIznos, 4);

                    db.Kupci.Update(kupac);
                    db.SaveChanges();
                }

            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Obrisi(int UplataID)
        {
            Uplata uplata = db.Uplate.Where(x => x.UplataID == UplataID).FirstOrDefault();

            int kupacID = uplata.KupacID;

            // regulisanje prema racunima

            Kupac kupac = db.Kupci.Where(x => x.KupacID == kupacID).FirstOrDefault();

            double IznosUplate = Math.Round(uplata.Iznos, 4);

            double? IznosKredita = kupac.Kredit;

            if (IznosUplate >= IznosKredita)
            {
                kupac.Kredit = 0;
                IznosUplate -= (double)IznosKredita;
                db.Kupci.Update(kupac);
                db.SaveChanges();
            }
            else
            {
                kupac.Kredit -= IznosUplate;
                IznosUplate = 0;
                db.Kupci.Update(kupac);
                db.SaveChanges();
            }

            if (IznosUplate > 0)
            {
                Racun polovican = db.Racuni.Where(x => x.KupacID == kupacID && x.DosadPlaceno > 0 && x.Placeno == false).FirstOrDefault();

                if (polovican != null)
                {

                    double PolovicanDosadPlaceno = Math.Round(polovican.DosadPlaceno, 4);

                    if (IznosUplate >= PolovicanDosadPlaceno)
                    {

                        polovican.DosadPlaceno = 0;
                        IznosUplate -= PolovicanDosadPlaceno;

                    }
                    else
                    {
                        polovican.DosadPlaceno -= IznosUplate;
                        IznosUplate = 0;
                    }

                    db.Racuni.Update(polovican);

                    db.SaveChanges();
                }

            }
            if (IznosUplate > 0)
            {

                List<Racun> racuni = db.Racuni.Where(x => x.Placeno == true && x.KupacID == kupacID).OrderByDescending(p => p.Datum).ToList();

                foreach (var x in racuni)
                {

                    double UkupnoZaNaplatu = Math.Round(x.UkupnoBezPDV + (x.UkupnoBezPDV * x.PDV), 4);

                    if (IznosUplate > 0)
                    {

                        if (IznosUplate >= UkupnoZaNaplatu)
                        {
                            x.DosadPlaceno = 0;
                            x.Placeno = false;
                            IznosUplate -= UkupnoZaNaplatu;
                            db.Racuni.Update(x);
                            db.SaveChanges();
                        }
                        else
                        {
                            x.Placeno = false;
                            x.DosadPlaceno -= IznosUplate;
                            IznosUplate = 0;
                            db.Racuni.Update(x);
                            db.SaveChanges();
                        }

                        if (IznosUplate <= 0)
                        {
                            break;
                        }
                    }

                }
            }


            db.Uplate.Remove(uplata);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}