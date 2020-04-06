using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sevdah.Models
{
    public class Racun
    {
        [Key]
        public int RacunID { get; set; }

        public string BrojRacuna  { get; set; }
        public string BrojFiskalnogRacuna { get; set; }

        public DateTime Datum { get; set; }

        public double UkupnoBezPDV { get; set; }
        public float PDV { get; set; }
        public int UkupnoZaNaplatu { get; set; } // sa PDV-om
        public double DosadPlaceno { get; set; }
        public bool Placeno { get; set; } // 

        public bool IsPredracun { get; set; } = false;

        [ForeignKey(nameof(Kupac))]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }
    }
}
