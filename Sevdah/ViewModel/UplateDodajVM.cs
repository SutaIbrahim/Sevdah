using System;

namespace Sevdah.ViewModel
{
    public class UplateDodajVM
    {
        public int KupacID { get; set; }
        public string NazivKupca { get; set; }

        public double IznosUplate { get; set; }

        public bool Dodaj { get; set; }
        public string BrojIzvoda { get; set; }

        public string DatumString { get; set; } = DateTime.Now.ToShortDateString();
        public DateTime Datum => Convert.ToDateTime(DatumString);
    }
}
