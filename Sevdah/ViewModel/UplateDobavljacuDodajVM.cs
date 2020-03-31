using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class UplateDobavljacuDodajVM
    {

        public int DobavljacID { get; set; }
        public string NazivDobavljaca { get; set; }

        public double IznosUplate { get; set; }

        public bool Dodaj { get; set; }
        public string BrojIzvoda { get; set; }

        public DateTime Datum { get; set; }


    }
}
