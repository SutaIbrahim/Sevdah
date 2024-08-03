using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.ViewModel;
using Sevdah.Models;
using Sevdah.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Sevdah.Controllers
{
    [Autorizacija(osoba: true)]
    public class RacuniController : Controller
    {
        private DBContext _db;
        public RacuniController(DBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region VIRMAN
        public IActionResult IndexVirman(RacuniIndexVM podaci)
        {
            RacuniIndexVM Model = new RacuniIndexVM();

            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {

                Model.listaRacuna = new List<RacuniIndexVM.Row>();

                if (podaci.srchTxt == null)
                {

                    Model.listaRacuna = _db.Racuni.AsNoTracking().Include(x => x.Kupac).Where(x => (x.IsPredracun == false && x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId) && x.Kupac.NazivKupca != "---").Select(x => new RacuniIndexVM.Row
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

                    Model.listaRacuna = _db.Racuni.AsNoTracking().OrderBy(d => d.Datum).Include(x => x.Kupac).Where(x => (x.IsPredracun == false && x.Kupac.NazivKupca.ToLower().Contains(podaci.srchTxt) || x.BrojRacuna.StartsWith(podaci.srchTxt)) && x.Kupac.NazivKupca != "---").Select(x => new RacuniIndexVM.Row
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
                for (int i = 2018; i < 2100; i++)
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
                    Model.zadnjiID = _db.Racuni.Where(x => !x.IsPredracun).Max(p => p.RacunID);
                    //
                }

                return View(Model);
            }

            //else

            Model = new RacuniIndexVM();
            Model.listaRacuna = new List<RacuniIndexVM.Row>();
            Model.listaRacuna = _db.Racuni.AsNoTracking().Where(x => x.IsPredracun == false && (x.Datum.Month == DateTime.Now.Month) && (x.Datum.Year == DateTime.Now.Year) & x.Kupac.NazivKupca != "---").Select(x => new RacuniIndexVM.Row
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
            for (int i = 2018; i < 2100; i++)
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
                Model.zadnjiID = _db.Racuni.Where(x=>!x.IsPredracun).Max(p => p.RacunID);
                //
            }

            return View(Model);
        }
        public IActionResult Dodaj()
        {
            RacuniDodajVM Model = new RacuniDodajVM();
            Model.racun = new Models.Racun();
            Model.listaKupaca = new List<SelectListItem>();
            Model.listaKupaca = _db.Kupci.Where(p => p.NazivKupca != "---").Select(x => new SelectListItem
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
                BrojRacuna = (_db.Racuni.Include(x => x.Kupac).Where(x => (x.IsPredracun == false && x.Datum.Year == DateTime.Now.Year) && x.Kupac.NazivKupca != "---").ToList().Count + 1).ToString() + "/" + DateTime.Now.Year.ToString().Substring(2, 2),
                Datum = DateTime.Now,
                DosadPlaceno = 0,
                KupacID = model.racun.KupacID,
                PDV = (float)0.17,
                UkupnoZaNaplatu = 0,
                UkupnoBezPDV = 0,
                Placeno = false,
                BrojFiskalnogRacuna = ""
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


            //

            if (Model.racun.DosadPlaceno > 0)
            {
                List<Racun> Racuni = _db.Racuni.Include(p => p.Kupac).Where(x => x.Datum.Month == DateTime.Now.Month || x.Datum.Month == (DateTime.Now.Month - 1)).ToList();
                if (Racuni.Count != 0)
                {
                    //zadnji ID !!!!
                    Model.zadnjiID = _db.Racuni.Where(x => !x.IsPredracun).Max(p => p.RacunID);
                    //
                }
                //
            }

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
            if (_db.RacunProizvodi.Where(x => x.RacunID == model.RacunId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault() != null)
            {
                RacunProizvod pronadjena = _db.RacunProizvodi.Where(x => x.RacunID == model.RacunId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault();
                Proizvod proizvodStavka = _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault();
                pronadjena.KolicinaKG += model.komada;
                _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg -= model.komada;
                pronadjena.IznosRabata += Math.Round((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100), 4);
                pronadjena.IznosBezPDV += Math.Round(((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV) - ((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100)), 4);
                _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault().UkupnoBezPDV += Math.Round(((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV) - ((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100)), 4);
                _db.SaveChanges();


                if (k.Kredit < ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno))
                {
                    r.DosadPlaceno += (double)k.Kredit;
                    k.Kredit = 0;
                    _db.SaveChanges();
                }
                else if (k.Kredit > ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno))
                {
                    double dug = ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno);
                    r.DosadPlaceno += dug;
                    k.Kredit -= dug;
                    r.Placeno = true;
                    _db.SaveChanges();
                }


                if (r.DosadPlaceno < ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno))
                {
                    r.Placeno = false;
                }
                else
                {
                    r.Placeno = true;
                }

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
            _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg -= model.komada;
            _db.SaveChanges();
            _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault().UkupnoBezPDV += Math.Round(novaStavka.IznosBezPDV, 4);
            _db.SaveChanges();


            if (k.Kredit < ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno))
            {
                r.DosadPlaceno += Math.Round((double)k.Kredit, 2);
                k.Kredit = 0;
                _db.SaveChanges();
            }
            else if (k.Kredit > ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno))
            {
                double dug = Math.Round(((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno), 2);
                r.DosadPlaceno += dug;
                k.Kredit -= dug;
                r.Placeno = true;
                _db.SaveChanges();
            }


            if (r.DosadPlaceno < ((r.UkupnoBezPDV + (r.UkupnoBezPDV * r.PDV)) - r.DosadPlaceno))
            {
                r.Placeno = false;
            }
            else
            {
                r.Placeno = true;
            }

            _db.SaveChanges();

            return RedirectToAction("Uredi", new { RacunId = model.RacunId });
        }
        public IActionResult Obrisi(int RacunProizvodId, int RacunId)
        {
            RacunProizvod stavka = _db.RacunProizvodi.Where(x => x.RacunProizvodID == RacunProizvodId).FirstOrDefault();

            Racun r = _db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault();
            _db.Kupci.Where(x => x.KupacID == r.KupacID).FirstOrDefault().Kredit += stavka.IznosBezPDV + (stavka.IznosBezPDV * r.PDV);

            _db.Racuni.Where(x => x.RacunID == stavka.RacunID).FirstOrDefault().UkupnoBezPDV -= stavka.IznosBezPDV;
            _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == stavka.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg += stavka.KolicinaKG;
            _db.RacunProizvodi.Remove(stavka);
            _db.SaveChanges();
            return RedirectToAction("Uredi", new { RacunId = RacunId });
        }
        public IActionResult ObrisiRacun(int RacunId)
        {
            Racun r = _db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault();
            List<RacunProizvod> listaStavki = _db.RacunProizvodi.Where(x => x.RacunID == RacunId).ToList();
            foreach (var item in listaStavki)
            {
                _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == item.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg += item.KolicinaKG;
            }
            _db.Kupci.Where(x => x.KupacID == r.KupacID).FirstOrDefault().Kredit += r.DosadPlaceno;
            _db.RacunProizvodi.RemoveRange(listaStavki);
            _db.SaveChanges();
            _db.Racuni.Remove(_db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault());
            _db.SaveChanges();
            return RedirectToAction("IndexVirman");
        }
        public IActionResult PrikaziRacunDokument(int RacunId)
        {
            byte[] docArray;
            RacuniReportVM Model = new RacuniReportVM();
            RacunReport report = new RacunReport();
            Model.racun = _db.Racuni.AsNoTracking().Where(x => x.RacunID == RacunId).Include(x => x.Kupac).ThenInclude(x => x.Grad).FirstOrDefault();
            Model.listaStavki = new List<RacunProizvod>();
            Model.listaStavki = _db.RacunProizvodi.AsNoTracking().Include(x => x.Proizvod).Include(x => x.Racun).Where(x => x.RacunID == RacunId).ToList();
            docArray = report.PrepareReport(Model);
            return File(docArray, "application/pdf");

        }
        public IActionResult UnosFiskalnogRacuna(string RacunID, string brojFiskalnog)
        {
            Racun r = _db.Racuni.FirstOrDefault(x => x.RacunID == int.Parse(RacunID));
            r.BrojFiskalnogRacuna = brojFiskalnog;
            _db.SaveChanges();
            return RedirectToAction("Uredi", new { RacunId = int.Parse(RacunID) });
        }

        public IActionResult UnosBrojaNarudzbe(string RacunID, string brojNarudzbe)
        {
            Racun r = _db.Racuni.FirstOrDefault(x => x.RacunID == int.Parse(RacunID));
            r.BrojNarudzbe = brojNarudzbe;
            _db.SaveChanges();
            return RedirectToAction("Uredi", new { RacunId = int.Parse(RacunID) });
        }

        #endregion

        #region GOTOVINA
        public IActionResult IndexGotovina(RacuniIndexVM podaci)
        {
            RacuniIndexVM Model;

            if (podaci != null && podaci.GodinaId != 0 && podaci.MjesecId != 0)
            {
                Model = new RacuniIndexVM();
                Model.listaRacuna = new List<RacuniIndexVM.Row>();
                Model.listaRacuna = _db.Racuni.Include(x => x.Kupac).Where(x => (x.IsPredracun == false && x.Datum.Month == podaci.MjesecId && x.Datum.Year == podaci.GodinaId) && x.Kupac.NazivKupca == "---").Select(x => new RacuniIndexVM.Row
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
                for (int i = 2018; i < 2100; i++)
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

                return View(Model);
            }

            Model = new RacuniIndexVM();
            Model.listaRacuna = new List<RacuniIndexVM.Row>();
            Model.listaRacuna = _db.Racuni.Include(x => x.Kupac).Where(x => (x.IsPredracun == false && x.Datum.Month == DateTime.Now.Month) && x.Kupac.NazivKupca == "---").Select(x => new RacuniIndexVM.Row
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
            for (int i = 2018; i < 2100; i++)
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

            return View(Model);

        }
        public IActionResult SnimiGotovniski()
        {
            Racun novi = new Racun
            {
                BrojRacuna = (_db.Racuni.Where(x => x.IsPredracun == false && x.Datum.Year == DateTime.Now.Year).ToList().Count + 1).ToString() + "/" + DateTime.Now.Year.ToString().Substring(2, 2) + " >>> Gotovinski",
                Datum = DateTime.Now,
                DosadPlaceno = 0,
                KupacID = _db.Kupci.Where(x => x.NazivKupca == "---").FirstOrDefault().KupacID,
                PDV = (float)0.17,
                UkupnoZaNaplatu = 0,
                UkupnoBezPDV = 0,
                Placeno = true,
                BrojFiskalnogRacuna = ""
            };

            _db.Racuni.Add(novi);
            _db.SaveChanges();
            return RedirectToAction("UrediGotovinski", new { RacunId = novi.RacunID });
        }
        public IActionResult UrediGotovinski(int RacunId)
        {
            RacuniUrediVM Model = new RacuniUrediVM();
            Model.racun = _db.Racuni.Include(x => x.Kupac).Where(x => x.RacunID == RacunId).FirstOrDefault();
            Model.listaStavki = new List<RacunProizvod>();
            Model.listaStavki = _db.RacunProizvodi.Include(x => x.Proizvod).Where(x => x.RacunID == RacunId).ToList();
            return View(Model);
        }
        public IActionResult SnimiStavkuGotovinski(RacuniDodajStavkuVM model)
        {
            //model.komada predstavlja kolicinu u KG
            if (_db.RacunProizvodi.Where(x => x.RacunID == model.RacunId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault() != null)
            {
                RacunProizvod pronadjena = _db.RacunProizvodi.Where(x => x.RacunID == model.RacunId && x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault();
                Proizvod proizvodStavka = _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault();
                pronadjena.KolicinaKG += model.komada;
                _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg -= model.komada;
                pronadjena.IznosRabata += Math.Round((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100), 4);
                pronadjena.IznosBezPDV += Math.Round(((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV) - ((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100)), 4);
                _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault().UkupnoBezPDV += Math.Round(((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV) - ((model.komada / proizvodStavka.Masa) * proizvodStavka.CijenaBezPDV * (pronadjena.Rabat / 100)), 4);
                _db.SaveChanges();
                return RedirectToAction("UrediGotovinski", new { RacunId = model.RacunId });
            }


            RacunProizvod novaStavka = new RacunProizvod
            {
                CijenaBezPDV = _db.Proizvodi.Where(x => x.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().CijenaBezPDV,
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
            _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == model.stavka.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg -= model.komada;
            _db.SaveChanges();
            _db.Racuni.Where(x => x.RacunID == model.RacunId).FirstOrDefault().UkupnoBezPDV += Math.Round(novaStavka.IznosBezPDV, 4);
            _db.SaveChanges();
            return RedirectToAction("UrediGotovinski", new { RacunId = model.RacunId });
        }
        public IActionResult DodajStavkuGotovinski(int RacunId)
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
            return View(Model);
        }
        public IActionResult ObrisiGotovinskiRacun(int RacunId)
        {
            List<RacunProizvod> listaStavki = _db.RacunProizvodi.Where(x => x.RacunID == RacunId).ToList();
            foreach (var item in listaStavki)
            {
                _db.Skladiste.Where(x => x.SkladisteID == _db.Proizvodi.Where(y => y.ProizvodID == item.ProizvodID).FirstOrDefault().SkladisteID).FirstOrDefault().KolicinaUKg += item.KolicinaKG;
            }
            _db.RacunProizvodi.RemoveRange(listaStavki);
            _db.SaveChanges();
            _db.Racuni.Remove(_db.Racuni.Where(x => x.RacunID == RacunId).FirstOrDefault());
            _db.SaveChanges();
            return RedirectToAction("IndexGotovina");
        }
        public IActionResult UnosFiskalnogRacunaGotovina(string RacunID, string brojFiskalnog)
        {
            Racun r = _db.Racuni.FirstOrDefault(x => x.RacunID == int.Parse(RacunID));
            r.BrojFiskalnogRacuna = brojFiskalnog;
            _db.SaveChanges();
            return RedirectToAction("UrediGotovinski", new { RacunId = int.Parse(RacunID) });
        }

        public IActionResult UnosBrojaNarudzbeGotovina(string RacunID, string brojNarudzbe)
        {
            Racun r = _db.Racuni.FirstOrDefault(x => x.RacunID == int.Parse(RacunID));
            r.BrojNarudzbe = brojNarudzbe;
            _db.SaveChanges();
            return RedirectToAction("UrediGotovinski", new { RacunId = int.Parse(RacunID) });
        }
        #endregion

        public IActionResult UzmiJsonPodatke()
        {
            CalendarApiVM Model = new CalendarApiVM();
            Model.listaRacuna = new List<CalendarApiVM.Row>();
            Model.listaRacuna = _db.Racuni.Select(x => new CalendarApiVM.Row
            {
                start = x.Datum.ToString("yyyy-MM-dd"),
                title = x.Kupac.NazivKupca
            }).ToList();
            return Json(Model.listaRacuna);
        }
    }
}