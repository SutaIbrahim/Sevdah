using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;

namespace Sevdah.Controllers
{

    [Autorizacija(osoba: true)]
    public class HomeController : Controller
    {
        DBContext db;

        public HomeController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Skladiste> skladiste = db.Skladiste.ToList();

            bool niskoStanje = false;

            foreach (var x in skladiste)
            {
                if (x.KolicinaUKg < 20)
                {
                    niskoStanje = true;
                }
            }

            return View(niskoStanje);
        }

        public IActionResult IncijalizacijaBaze(int? brojRacuna = null)
        {
            if (!db.Skladiste.Any())
            {

                Skladiste sirova2 = new Skladiste();
                sirova2.VrstaKafe = "SIROVA KAFA";
                sirova2.KolicinaUKg = 0;
                db.Skladiste.Add(sirova2);
                db.SaveChanges();

                Skladiste przenaRefuza = new Skladiste();
                przenaRefuza.VrstaKafe = "Pržena kafa REFUZA";
                przenaRefuza.KolicinaUKg = 0;
                db.Skladiste.Add(przenaRefuza);
                db.SaveChanges();

                Skladiste sirova = new Skladiste();
                sirova.VrstaKafe = "Sirova kafa 1000g";
                sirova.KolicinaUKg = 0;
                db.Skladiste.Add(sirova);
                db.SaveChanges();

                Skladiste przena = new Skladiste();
                przena.VrstaKafe = "Pržena kafa 500g";
                przena.KolicinaUKg = 0;
                db.Skladiste.Add(przena);
                db.SaveChanges();
          
                Skladiste mljevena500 = new Skladiste();
                mljevena500.VrstaKafe = "Mljevena kafa 500g";
                mljevena500.KolicinaUKg = 0;
                db.Skladiste.Add(mljevena500);
                db.SaveChanges();

                Skladiste mljevena200 = new Skladiste();
                mljevena200.VrstaKafe = "Mljevena kafa 200g";
                mljevena200.KolicinaUKg = 0;
                db.Skladiste.Add(mljevena200);
                db.SaveChanges();

                Skladiste mljevena100 = new Skladiste();
                mljevena100.VrstaKafe = "Mljevena kafa 100g";
                mljevena100.KolicinaUKg = 0;
                db.Skladiste.Add(mljevena100);
                db.SaveChanges();


                // 


                Proizvod SevdahSirova1000 = new Proizvod();
                SevdahSirova1000.BarKod = "3871661000077";
                SevdahSirova1000.CijenaBezPDV = 7.9;
                SevdahSirova1000.Masa = (float)1;
                SevdahSirova1000.SkladisteID = sirova.SkladisteID;
                SevdahSirova1000.Naziv = "Sirova kafa 1000gr";
                db.Proizvodi.Add(SevdahSirova1000);
                db.SaveChanges();

                Proizvod SevdahPrzena500 = new Proizvod();
                SevdahPrzena500.BarKod = "3871661000060";
                SevdahPrzena500.CijenaBezPDV = 8.9;
                SevdahPrzena500.Masa = (float)0.5;
                SevdahPrzena500.SkladisteID = przena.SkladisteID;
                SevdahPrzena500.Naziv = "Pržena kafa 500gr";
                db.Proizvodi.Add(SevdahPrzena500);
                db.SaveChanges();

                Proizvod SevdahMljevena500 = new Proizvod();
                SevdahMljevena500.BarKod = "3871661000039";
                SevdahMljevena500.CijenaBezPDV=8.9;
                SevdahMljevena500.Masa = (float)0.5;
                SevdahMljevena500.SkladisteID = mljevena500.SkladisteID;
                SevdahMljevena500.Naziv = "Mljevena kafa 500gr";
                db.Proizvodi.Add(SevdahMljevena500);
                db.SaveChanges();

                Proizvod SevdahMljevena200 = new Proizvod();
                SevdahMljevena200.BarKod = "3871661000022";
                SevdahMljevena200.CijenaBezPDV = 8.9;
                SevdahMljevena200.Masa = (float)0.2;
                SevdahMljevena200.SkladisteID = mljevena200.SkladisteID;
                SevdahMljevena200.Naziv = "Mljevena kafa 200gr";
                db.Proizvodi.Add(SevdahMljevena200);
                db.SaveChanges();

                Proizvod SevdahMljevena100 = new Proizvod();
                SevdahMljevena100.BarKod = "3871661000015";
                SevdahMljevena100.CijenaBezPDV = 8.9;
                SevdahMljevena100.Masa = (float)0.5;
                SevdahMljevena100.SkladisteID = mljevena100.SkladisteID;
                SevdahMljevena100.Naziv = "Mljevena kafa 100gr";
                db.Proizvodi.Add(SevdahMljevena100);
                db.SaveChanges();
     
                Proizvod SevdahPrzenaRefuza = new Proizvod();
                SevdahPrzenaRefuza.BarKod = "---";
                SevdahPrzenaRefuza.CijenaBezPDV = 8.9;
                SevdahPrzenaRefuza.Masa = (float)1;
                SevdahPrzenaRefuza.SkladisteID = przena.SkladisteID;
                SevdahPrzenaRefuza.Naziv = "Pržena kafa REFUZA";
                db.Proizvodi.Add(SevdahPrzenaRefuza);
                db.SaveChanges();

                Proizvod SevdahSirova = new Proizvod();
                SevdahSirova.BarKod = "---";
                SevdahSirova.CijenaBezPDV = 7.9;
                SevdahSirova.Masa = (float)1;
                SevdahSirova.SkladisteID = sirova2.SkladisteID;
                SevdahSirova.Naziv = "SIROVA KAFA";
                db.Proizvodi.Add(SevdahSirova);
                db.SaveChanges();


                Grad grad = new Grad();
                grad.Naziv = "Mostar";
                db.Gradovi.Add(grad);
                db.SaveChanges();

                Grad grad2 = new Grad();
                grad2.Naziv = "Stolac";
                db.Gradovi.Add(grad2);
                db.SaveChanges();

                Grad grad3 = new Grad();
                grad3.Naziv = "Jablanica";
                db.Gradovi.Add(grad3);
                db.SaveChanges();


                Kupac kupac = new Kupac();
                kupac.GradID = grad.GradID;
                kupac.ID_broj = "00000000000000";
                kupac.PDV_broj = "0000000000000";
                kupac.Kredit = 0;
                kupac.Adresa = "adresa";
                kupac.NazivKupca = "---";
                db.Kupci.Add(kupac);
                db.SaveChanges();

                Kupac kupac2 = new Kupac();
                kupac2.GradID = grad.GradID;
                kupac2.ID_broj = "00000000000000";
                kupac2.PDV_broj = "0000000000000";
                kupac2.Kredit = 0;
                kupac2.Adresa = "adresa";
                kupac2.NazivKupca = "zTest";
                db.Kupci.Add(kupac2);
                db.SaveChanges();


                if (brojRacuna == null)
                {
                    // promijeniti 30 po potrebi !!!
                    for (int i = 0; i < 30; i++)
                    {
                        Racun racun = new Racun();
                        racun.BrojRacuna = "inicijalni racuni (pocetak rada aplikacije)";
                        racun.Datum = DateTime.Now.AddMonths(-2);
                        racun.DosadPlaceno = 0;
                        racun.Placeno = true;
                        racun.PDV = 0;
                        racun.UkupnoBezPDV = 0;
                        racun.UkupnoZaNaplatu = 0;
                        racun.KupacID = kupac2.KupacID;
                        db.Racuni.Add(racun);
                        db.SaveChanges();
                    }
                }
                else
                {
                    for (int i = 0; i < brojRacuna; i++)
                    {
                        Racun racun = new Racun();
                        racun.BrojRacuna = "inicijalni racuni (pocetak rada aplikacije)";
                        racun.Datum = DateTime.Now.AddMonths(-2);
                        racun.DosadPlaceno = 0;
                        racun.Placeno = true;
                        racun.PDV = 0;
                        racun.UkupnoBezPDV = 0;
                        racun.UkupnoZaNaplatu = 0;
                        racun.KupacID = kupac2.KupacID;
                        db.Racuni.Add(racun);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Sevdah.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
