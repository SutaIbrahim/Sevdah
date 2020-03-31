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
    [Autorizacija(osoba: true)]

    public class UplateDobavljaciController : Controller
    {
        DBContext db;

        public UplateDobavljaciController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index(UplateDobavljaciIndexVM podaci)
        {
            UplateDobavljaciIndexVM model = new UplateDobavljaciIndexVM();

            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {

                if (podaci.srchTxt == null)
                {
                    model.Uplate = db.UplateDobavljacu.Include(p => p.Dobavljac).Where(x => x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId).ToList();
                }
                else
                {
                    // tacan naziv ili broj izvoda
                    model.Uplate = db.UplateDobavljacu.Include(p => p.Dobavljac).Include(z=>z.RacunDobavljaca).Where(x =>(x.Dobavljac.Naziv.StartsWith(podaci.srchTxt) || x.Brojizvoda.StartsWith(podaci.srchTxt))).ToList();
                }

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
                model.srchTxt = podaci.srchTxt;

                return View(model);

            }

            //else

            model.Uplate = db.UplateDobavljacu.Include(x => x.Dobavljac).Where(x => x.Datum.Month == DateTime.Now.Month && x.Datum.Year == DateTime.Now.Year).ToList();

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

            model.GodinaId = DateTime.Now.Year;
            model.MjesecId = DateTime.Now.Month;

            return View(model);
        }

        public IActionResult Dodaj(int DobavljacId)
        {
            UplateDobavljacuDodajVM model = new UplateDobavljacuDodajVM();

            model.DobavljacID = DobavljacId;

            model.NazivDobavljaca = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacId).FirstOrDefault().Naziv;

            model.IznosUplate = 0;

            model.Dodaj = true;

            model.Datum = DateTime.Now;

            model.BrojIzvoda = "";

            return View(model);
        }
        public IActionResult Snimi(UplateDobavljacuDodajVM model)
        {
            if (model.Dodaj == true)
            {
                UplataDobavljacu nova = new UplataDobavljacu();

                nova.Iznos = model.IznosUplate;
                nova.DobavljacID = model.DobavljacID;
                nova.Datum = model.Datum;
                nova.Brojizvoda = model.BrojIzvoda;

                db.UplateDobavljacu.Add(nova);
                db.SaveChanges();

                // regulisanje uplata prema racunima

                double NoviIznos = Math.Round(model.IznosUplate, 4);

                List<RacunDobavljaca> racuni = db.RacuniDobavljaca.Where(x => x.Placeno == false && x.DobavljacID == nova.DobavljacID).ToList();

                foreach (var x in racuni)
                {


                    double DosadPlaceno = x.DosadPlaceno;
                    double IznosRacuna = x.UkupnoSaPDV;     // ukupno za naplatu

                    double potrebno = Math.Round(IznosRacuna - DosadPlaceno, 4);

                    if (NoviIznos >= potrebno)
                    {
                        NoviIznos -= potrebno;
                        x.DosadPlaceno = Math.Round(x.DosadPlaceno, 4) + potrebno;
                        x.Placeno = true;
                    }
                    else
                    {
                        x.DosadPlaceno = Math.Round(x.DosadPlaceno, 4) + NoviIznos;
                        NoviIznos = 0;
                    }

                    if (Math.Round(x.DosadPlaceno, 4) == Math.Round(IznosRacuna, 4))
                    {
                        x.Placeno = true;
                    }

                    if (NoviIznos == 0)
                    {
                        db.RacuniDobavljaca.Update(x);
                        db.SaveChanges();
                        break;
                    }

                    db.RacuniDobavljaca.Update(x);
                    db.SaveChanges();

                }

                if (NoviIznos > 0)
                {
                    Dobavljac dobavljac = db.Dobavljaci.Where(x => x.DobavljacID == model.DobavljacID).FirstOrDefault();
                    dobavljac.Kredit += Math.Round(NoviIznos, 4);

                    db.Dobavljaci.Update(dobavljac);
                    db.SaveChanges();
                }
            }


            return RedirectToAction(nameof(Index));
        }


        public IActionResult Obrisi(int UplataID)
        {
            UplataDobavljacu uplata = db.UplateDobavljacu.Where(x => x.UplataDobavljacuID == UplataID).FirstOrDefault();

            int DobavljacID = uplata.DobavljacID;

            // regulisanje prema racunima

            Dobavljac dobavljac = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacID).FirstOrDefault();

            double IznosUplate = Math.Round(uplata.Iznos, 4);

            double? IznosKredita = dobavljac.Kredit;

            if (IznosUplate >= IznosKredita)
            {
                dobavljac.Kredit = 0;
                IznosUplate -= (double)IznosKredita;
                db.Dobavljaci.Update(dobavljac);
                db.SaveChanges();
            }
            else
            {
                dobavljac.Kredit -= IznosUplate;
                IznosUplate = 0;
                db.Dobavljaci.Update(dobavljac);
                db.SaveChanges();
            }

            if (IznosUplate > 0)
            {
                RacunDobavljaca polovican = db.RacuniDobavljaca.Where(x => x.DobavljacID == DobavljacID && x.DosadPlaceno > 0 && x.Placeno == false).FirstOrDefault();

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

                    db.RacuniDobavljaca.Update(polovican);
                    db.SaveChanges();
                }

            }
            if (IznosUplate > 0)
            {

                List<RacunDobavljaca> racuni = db.RacuniDobavljaca.Where(x => x.Placeno == true && x.DobavljacID == DobavljacID).OrderByDescending(p => p.Datum).ToList();

                foreach (var x in racuni)
                {

                    double UkupnoZaNaplatu = Math.Round(x.UkupnoSaPDV, 4);

                    if (IznosUplate > 0)
                    {

                        if (IznosUplate >= UkupnoZaNaplatu)
                        {
                            x.DosadPlaceno = 0;
                            x.Placeno = false;
                            IznosUplate -= UkupnoZaNaplatu;
                            db.RacuniDobavljaca.Update(x);
                            db.SaveChanges();
                        }
                        else
                        {
                            x.Placeno = false;
                            x.DosadPlaceno -= IznosUplate;
                            IznosUplate = 0;
                            db.RacuniDobavljaca.Update(x);
                            db.SaveChanges();
                        }

                        if (IznosUplate <= 0)
                        {
                            break;
                        }
                    }

                }
            }


            db.UplateDobavljacu.Remove(uplata);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
    }
}