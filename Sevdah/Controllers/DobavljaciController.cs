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

    public class DobavljaciController : Controller
    {
        DBContext db;

        public DobavljaciController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            DobavljacIndexVM model = new DobavljacIndexVM();

            model.Dobavljaci = db.Dobavljaci.Include(x => x.Grad).Select(y => new DobavljacIndexVM.Row()
            {
                DobavljacID = y.DobavljacID,
                Naziv = y.Naziv,
                ID_broj = y.ID_broj,
                PDV_broj = y.PDV_broj,
                Adresa = y.Adresa,
                Grad = y.Grad.Naziv,
                ZiroRacun = y.ZiroRacun,
                Telefon = y.Telefon,
                Kredit = y.Kredit
                //Dugovanje = (db.Racuni.Where(t => t.KupacID == y.DobavljacID && t.Placeno == false).Sum(p => p.UkupnoZaNaplatu)) - (db.Racuni.Where(t => t.KupacID == y.KupacID && t.Placeno == false).Sum(p => p.DosadPlaceno)) - (db.Uplate.Where(r => r.KupacID == y.KupacID).Sum(e => e.Iznos))
            }).ToList();

            return View(model);
        }

        public IActionResult Pretraga(string srchTxt)
        {
            if (srchTxt == null)
                return RedirectToAction(nameof(Index));

            DobavljacIndexVM model = new DobavljacIndexVM();

            srchTxt = srchTxt.ToLower();

            model.Dobavljaci = db.Dobavljaci.Include(x => x.Grad).Where(p => p.Naziv.ToLower().Contains(srchTxt)).Select(y => new DobavljacIndexVM.Row()
            {
                DobavljacID = y.DobavljacID,
                Naziv = y.Naziv,
                ID_broj = y.ID_broj,
                PDV_broj = y.PDV_broj,
                Adresa = y.Adresa,
                Grad = y.Grad.Naziv,
                ZiroRacun = y.ZiroRacun,
                Telefon = y.Telefon,
                Kredit = y.Kredit
                //Dugovanje = (db.Racuni.Where(t => t.KupacID == y.DobavljacID && t.Placeno == false).Sum(p => p.UkupnoZaNaplatu)) - (db.Racuni.Where(t => t.KupacID == y.KupacID && t.Placeno == false).Sum(p => p.DosadPlaceno)) - (db.Uplate.Where(r => r.KupacID == y.KupacID).Sum(e => e.Iznos))
            }).ToList();

            model.srchTxt = srchTxt;

            return View("Index", model);
        }

        public IActionResult Dodaj()
        {
            DobavljacDodajVM model = new DobavljacDodajVM();

            model.dobavljac = new Dobavljac();

            model.dobavljac.Kredit = 0;
            model.gradovi = db.Gradovi.Select(x => new SelectListItem
            {
                Text = x.Naziv,
                Value = x.GradID.ToString()
            }).ToList();


            return View(model);
        }

        public IActionResult Uredi(int DobavljacId)
        {
            Dobavljac dobavljac = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacId).FirstOrDefault();

            DobavljacDodajVM model = new DobavljacDodajVM();

            model.dobavljac = dobavljac;

            model.gradovi = db.Gradovi.Select(x => new SelectListItem
            {

                Text = x.Naziv,
                Value = x.GradID.ToString()

            }).ToList();

            return View(model);

        }

        public IActionResult Snimi(DobavljacDodajVM model)
        {
            if (!ModelState.IsValid)
            {
                DobavljacDodajVM model2 = new DobavljacDodajVM();

                model2.dobavljac = model.dobavljac;
                model2.gradovi = db.Gradovi.Select(x => new SelectListItem
                {

                    Text = x.Naziv,
                    Value = x.GradID.ToString()

                }).ToList();


                return View("Dodaj", model2);

            }

            Dobavljac dobavljac = model.dobavljac;

            dobavljac.Kredit = 0;

            db.Dobavljaci.Add(dobavljac);

            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult SnimiUredi(DobavljacDodajVM model)
        {
            if (!ModelState.IsValid)
            {

                DobavljacDodajVM model2 = new DobavljacDodajVM();

                model2.dobavljac = model.dobavljac;
                model2.gradovi = db.Gradovi.Select(x => new SelectListItem
                {

                    Text = x.Naziv,
                    Value = x.GradID.ToString()

                }).ToList();

                return View("Uredi", model2);
            }


            Dobavljac edit;
            edit = db.Dobavljaci.Where(x => x.DobavljacID == model.dobavljac.DobavljacID).FirstOrDefault();

            edit.GradID = model.dobavljac.GradID;
            edit.ID_broj = model.dobavljac.ID_broj;
            edit.PDV_broj = model.dobavljac.PDV_broj;
            edit.Naziv = model.dobavljac.Naziv;
            edit.Adresa = model.dobavljac.Adresa;
            edit.Telefon = model.dobavljac.Telefon;
            edit.ZiroRacun = model.dobavljac.ZiroRacun;
            edit.Kredit = model.dobavljac.Kredit;

            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Obrisi(int DobavljacId)
        {
            Dobavljac dobavljac = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacId).FirstOrDefault();

            db.Dobavljaci.Remove(dobavljac);
            db.SaveChanges();

            List<ProizvodDobavljac> lista = db.ProizvodDobavljac.Where(x => x.DobavljacID == DobavljacId).ToList();

            foreach (var x in lista)
            {
                db.ProizvodDobavljac.Remove(x);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult IndexProizvoda(int DobavljacId)
        {
            IndexProizvodaVM model = new IndexProizvodaVM();

            model.proizvodi = db.ProizvodDobavljac.Where(x => x.DobavljacID == DobavljacId).Include(p => p.Dobavljac).Include(y => y.VrstaProizvoda).ToList();
            model.NazivDobavljaca = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacId).FirstOrDefault().Naziv;
            model.DobavljacId = DobavljacId;

            return View(model);
        }


        public IActionResult DodajProizvod(int DobavljacId)
        {
            DodajProizvodDobavljacVM model = new DodajProizvodDobavljacVM();

            model.Proizvodi = db.VrsteProizvoda.Select(x => new SelectListItem
            {
                Value = x.VrstaProizvodaID.ToString(),
                Text = x.Naziv
            }).ToList();

            model.DobavljacId = DobavljacId;

            model.ProizvodDobavljac = new ProizvodDobavljac();

            model.NazivDobavljaca = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacId).FirstOrDefault().Naziv;

            return View(model);
        }

        public IActionResult SnimiProizvod(DodajProizvodDobavljacVM model)
        {

            ProizvodDobavljac novi = model.ProizvodDobavljac;

            novi.DobavljacID = model.DobavljacId;

            db.ProizvodDobavljac.Add(novi);
            db.SaveChanges();

            return RedirectToAction(nameof(IndexProizvoda), new { DobavljacId = model.DobavljacId });
        }


        public IActionResult ObrisiProizvod(int PDID)
        {
            ProizvodDobavljac del = db.ProizvodDobavljac.Where(x => x.ProizvodDobavljacID == PDID).FirstOrDefault();

            int id = del.DobavljacID;

            db.ProizvodDobavljac.Remove(del);
            db.SaveChanges();

            return RedirectToAction(nameof(IndexProizvoda), new { DobavljacId = id });
        }

        public IActionResult NapraviKontoKarticu(int DobavljacId)
        {
            DobavljacNapraviKontoKarticuVM Model = new DobavljacNapraviKontoKarticuVM();
            Model.datumOdString = DateTime.Now.AddDays(-31).ToShortDateString();
            Model.datumDoString = DateTime.Now.ToShortDateString();
            Model.DobavljacID = DobavljacId;
            Model.Grad = db.Dobavljaci.Where(x => x.DobavljacID == DobavljacId).Include(p => p.Grad).FirstOrDefault().Grad.Naziv;
            return View(Model);
        }

        public IActionResult PrikaziKontoKarticu(DobavljacNapraviKontoKarticuVM model)
        {
            List<RacunDobavljaca> listaRacunaDb = new List<RacunDobavljaca>();

            List<UplataDobavljacu> listaUplataDb = new List<UplataDobavljacu>();

            //prethodno stanje !
            List<RacunDobavljaca> listaRacunaDbPRE = new List<RacunDobavljaca>();
            List<UplataDobavljacu> listaUplataDbPRE = new List<UplataDobavljacu>();

            double dugPRE = 0;
            double uplataPRE = 0;
            DateTime pocetnoStanjeAplikacije = new DateTime(2018, 7, 25); // na taj dan uneseni svi dugovi

            //PRETHODNO DUGOVANJE
            listaRacunaDbPRE = db.RacuniDobavljaca.Include(x => x.Dobavljac).Where(x => (x.Datum >= pocetnoStanjeAplikacije && x.Datum < model.datumOd) && x.DobavljacID == model.DobavljacID).ToList();

            listaUplataDbPRE = db.UplateDobavljacu.Include(x => x.Dobavljac).Where(x => (x.Datum >= pocetnoStanjeAplikacije && x.Datum < model.datumOd) && x.DobavljacID == model.DobavljacID).ToList();

            for (int i = 0; i < listaRacunaDbPRE.Count(); i++)
            {
                uplataPRE += listaRacunaDbPRE[i].UkupnoSaPDV;
            }
            for (int i = 0; i < listaUplataDbPRE.Count(); i++)
            {
                dugPRE += listaUplataDbPRE[i].Iznos;
            }
            //

            listaRacunaDb = db.RacuniDobavljaca.Include(x => x.Dobavljac).Where(x => (x.Datum >= model.datumOd && x.Datum <= model.datumDo.AddHours(8)) && x.DobavljacID == model.DobavljacID).ToList();

            listaUplataDb = db.UplateDobavljacu.Include(x => x.Dobavljac).Where(x => (x.Datum >= model.datumOd && x.Datum <= model.datumDo.AddHours(8)) && x.DobavljacID == model.DobavljacID).ToList();

            DobavljacKontoKartica Model = new DobavljacKontoKartica();
            Model.DatumOd = model.datumOd;
            Model.DatumDo = model.datumDo;
            Model.DobavljacId = model.DobavljacID;
            Model.Grad = model.Grad;
            Model.redovi = new List<DobavljacKontoKartica.Row>();
            Model.Saldo = 0;

            Model.prethodnoDugovanje = uplataPRE - dugPRE;

            ////dodavanje prvog reda, tj prethodnog stanja prije izabranog datuma
            //Model.redovi.Add(new DobavljacKontoKartica.Row
            //{
            //    Datum = model.datumOd,
            //    Duguje = dugPRE,
            //    Potrazuje = uplataPRE,
            //    Saldo = dugPRE - uplataPRE,
            //    VezniDokument = "Prethodno stanje"

            //});

            for (int i = 0; i < listaRacunaDb.Count(); i++)
            {
                Model.redovi.Add(new DobavljacKontoKartica.Row
                {
                    Datum = listaRacunaDb[i].Datum,
                    Potrazuje = listaRacunaDb[i].UkupnoSaPDV,
                    Duguje = 0,
                    Saldo = 0,
                    VezniDokument = listaRacunaDb[i].BrojRacuna
                });
            }
            for (int i = 0; i < listaUplataDb.Count(); i++)
            {
                Model.redovi.Add(new DobavljacKontoKartica.Row
                {
                    Datum = listaUplataDb[i].Datum,
                    Potrazuje = 0,
                    Duguje = listaUplataDb[i].Iznos,
                    Saldo = 0,
                    VezniDokument = listaUplataDb[i].Brojizvoda
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

            KontoDobavljacReport novi = new KontoDobavljacReport();

            Model.NazivDobavljaca = db.Dobavljaci.Where(x => x.DobavljacID == model.DobavljacID).FirstOrDefault().Naziv;
            Model.AdresaDobavljaca = db.Dobavljaci.Where(x => x.DobavljacID == model.DobavljacID).FirstOrDefault().Adresa;
            Model.Saldo = Model.SumaPotrazuje - Model.SumaDuguje;
            byte[] docArray = novi.PrepareReport(Model);
            return File(docArray, "application/pdf");
        }


    }
}