using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sevdah.Data;
using Sevdah.Helpers;
using Sevdah.Models;
using Sevdah.ViewModel;

namespace Sevdah.Controllers
{
    public class AuthenticationController : Controller
    {

        private DBContext db;

        public AuthenticationController(DBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            // dodavanje korisnika u bazu 
            if (!db.KorisnickiNalog.Any())
            {
                KorisnickiNalog nalog = new KorisnickiNalog();
                nalog.KorisnickoIme = "sevdah";
                nalog.Lozinka = "sevdah1998";
                db.KorisnickiNalog.Add(nalog);
                db.SaveChanges();
            }
            //

            return View(new LoginVM()
            {
                zapamtiPass = true
            });
        }
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            KorisnickiNalog korisnik = db.KorisnickiNalog.Where(x => x.KorisnickoIme == model.username && x.Lozinka == model.password).FirstOrDefault();

            if (korisnik == null)
            {
                ViewData["error_poruka"] = "Pogrešan username ili password";
                return View("Index", model);
            }

            HttpContext.SetLogiraniKorisnik(korisnik, model.zapamtiPass);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            string token= HttpContext.GetTrenutniToken();


            return RedirectToAction("Obrisi", "Sesija");
        }



    }
}