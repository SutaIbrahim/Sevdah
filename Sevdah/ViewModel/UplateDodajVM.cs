using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class UplateDodajVM
    {

        public int KupacID { get; set; }
        public string NazivKupca { get; set; }

        public double IznosUplate { get; set; }

        public bool Dodaj { get; set; }
        public string BrojIzvoda { get; set; }


        public DateTime Datum { get; set; }

    }
}
